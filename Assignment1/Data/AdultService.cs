using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FileData;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Assignment1.Data
{
    public class AdultService : IAdultService
    {
        private const string uri = "http://localhost:5000";

        public AdultService()
        {
            
        }

        public async Task<IList<Adult>> getAdult()
        {
            IList<Adult> result;

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(uri+"/adult");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add
                    (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(uri+"/adult").Result;
                var data = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<IList<Adult>>(data);
            }
            return result;
        }

        public async Task Add(Adult newAdult)
        {
            HttpClient client = new HttpClient();
            string adultAsJson = JsonSerializer.Serialize(newAdult);
            HttpContent content = new StringContent(
                adultAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri + "/adult", content);
        }

        public async Task Remove(Adult adultToRemove)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync(uri+"/"+adultToRemove.Id);
        }
        
    }
}