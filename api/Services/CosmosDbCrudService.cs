using AzureBackendApp.Models;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBackendApp.Services
{
    public class CosmosDbCrudService : ICrudService<TodoItem>
    {
        private readonly Container _container;

        public CosmosDbCrudService(CosmosClient cosmosClient)
        {
            var dbName = Environment.GetEnvironmentVariable("CosmosDbDatabaseName");
            var containerName = Environment.GetEnvironmentVariable("CosmosDbContainerName");
            _container = cosmosClient.GetContainer(dbName, containerName);
        }

        public async Task<TodoItem> CreateAsync(TodoItem item)
        {
            item.Id ??= Guid.NewGuid().ToString();
            var response = await _container.CreateItemAsync(item, new PartitionKey(item.Id));
            return response.Resource;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<TodoItem>("SELECT * FROM c");
            var results = new List<TodoItem>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        public async Task<TodoItem> GetByIdAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<TodoItem>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<TodoItem> UpdateAsync(string id, TodoItem item)
        {
            item.Id = id;
            var response = await _container.UpsertItemAsync(item, new PartitionKey(id));
            return response.Resource;
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<TodoItem>(id, new PartitionKey(id));
        }
    }
}
