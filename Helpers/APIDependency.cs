using DigitalAfterlife2._0.Models;
using System.Text.Json;

namespace DigitalAfterlife2._0.Helpers
{
    public class APIDependency
    {
        private static Uri BaseAddress = new Uri("https://digitalafterlifeapi.azurewebsites.net/"); // ändra om api inte kommer upp

        public APIDependency()
        {
           
        }


        public async Task<List<StreamingService>> GetStreamingServices()
        {
            List<StreamingService> services = new List<StreamingService>();

            using(var client  = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                HttpResponseMessage response = await client.GetAsync("api/StreamingService");
                if(response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    services = JsonSerializer.Deserialize<List<StreamingService>>(responseString);
                }
            }
            return services;
        }

        public async Task<StreamingService> GetOneStreamService(int id)
        {
            StreamingService service = new StreamingService();

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                HttpResponseMessage response = await client.GetAsync("api/StreamingService/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    service = JsonSerializer.Deserialize<StreamingService>(responseString);
                }
            }


            return service;
        }


        public async Task SaveNewStreamingService(StreamingService newService)
        {
            var service = (await GetStreamingServices()).Where(x => x.Id == newService.Id).SingleOrDefault();

            if (service == null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = BaseAddress;
                    var json = JsonSerializer.Serialize(newService);
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("api/StreamingService", httpContent);
                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = BaseAddress;
                    var json = JsonSerializer.Serialize(newService);
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync("api/StreamingService/" + newService.Id, httpContent);
                }
            }
            

        }

        public async Task DeleteStreamingService(int index)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                HttpResponseMessage response = await client.DeleteAsync("api/StreamingService/" + index);
            }
        }


    }
}
