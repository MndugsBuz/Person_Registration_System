
   fetch('https://localhost:7042/Users?id=1')
   .then(Response => Response.json())
   .then((data) => console.log(data));