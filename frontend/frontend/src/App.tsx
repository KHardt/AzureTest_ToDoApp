import React, { useEffect, useState } from 'react';

function App() {
  const [data, setData] = useState<string | null>(null);

  useEffect(() => {
    fetch('/api/Function1')
      .then(res => res.json())
      .then(json => {
        console.log(json);
        setData(JSON.stringify(json, null, 2));
      })
      .catch(err => {
        console.error('Error fetching data:', err);
        setData('Error fetching dat');
      });
  }, []);

  return (
    <div>
      <h1>Continuous Deployment Test</h1>
      <pre>{data || 'Loading...'}</pre>
    </div>
  );
}

export default App;
