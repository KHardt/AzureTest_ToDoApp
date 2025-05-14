using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureBackendApp.Services
{
    public interface ICrudService<T>
    {
        Task<T> CreateAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> UpdateAsync(string id, T item);
        Task DeleteAsync(string id);
    }
}
