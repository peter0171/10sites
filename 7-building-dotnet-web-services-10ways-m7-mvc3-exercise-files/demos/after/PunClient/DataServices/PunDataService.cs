using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PunClient.Transports;

namespace PunClient.DataServices
{
    class PunDataService
    {
        public PunDataService()
        {
        }

        public async Task<Pun[]> GetPuns()
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://localhost:56204/Puns");
            var resultContent = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Pun[]>(resultContent);
        }

        public async Task<Pun> GetPunByID(int punID)
        {
            var client = new HttpClient();
            var result = await client.GetAsync(string.Format("http://localhost:56204/Puns/GetPun/{0}", punID));
            var resultContent = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Pun>(resultContent);
        }

        public async void CreatePun(Pun pun)
        {
            var client = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(pun);
            var result = await client.PostAsync("http://localhost:56204/Puns/Create",
                             new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json"));
            var resultContent = await result.Content.ReadAsStringAsync();
            pun = JsonConvert.DeserializeObject<Pun>(resultContent);
        }

        public async void UpdatePun(Pun pun)
        {
            var client = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(pun);
            var result = await client.PutAsync("http://localhost:56204/Puns/Update",
                                new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json"));
            var resultContent = await result.Content.ReadAsStringAsync();
            pun = JsonConvert.DeserializeObject<Pun>(resultContent);
        }

        public async void DeletePun(int punID)
        {
            var client = new HttpClient();
            var result = await client.DeleteAsync(string.Format("http://localhost:56204/Puns/Delete/{0}", punID));
            result.EnsureSuccessStatusCode();
        }
    }
}
