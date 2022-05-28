using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LoginPrueba.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace LoginPrueba.Helpers
{
    public class RetosAPI 
    {
        HttpClient client;

        public List<Challenge> data { get; private set; }
        public string title { get; private set; }
        public string description { get; private set; }
        public string currentPoints { get; private set; }
        public string totalPoints { get; private set; }
        public string RestUrl { get; set; }
        public RetosAPI()
        {
            client = new HttpClient();
            RestUrl = " https://horuschallenges.azurewebsites.net/api/Challenges";
        }
        public async Task<List<Challenge>> GetRetos(string authKey)
        {
            var client = new HttpClient();            
            client.DefaultRequestHeaders.Add("Authorization", authKey);
            var response = await client.GetAsync(RestUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<List<Challenge>>(content);
            }            
            return data;
        }
        public async Task<string> GetPoints(string authKey)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", authKey);
            var response = await client.GetAsync(RestUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var tmp = JsonConvert.DeserializeObject<Challenge>(content);
                currentPoints = tmp.CurrentPoints;
            }
            return currentPoints;
        }
        public async Task<string> GetTotalPoints(string authKey)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", authKey);
            var response = await client.GetAsync(RestUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var tmp = JsonConvert.DeserializeObject<Challenge>(content);
                totalPoints = tmp.TotalPoints;
            }
            return totalPoints;
        }
        public async Task<string> GetTitle(string authKey)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", authKey);
            var response = await client.GetAsync(RestUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var tmp = JsonConvert.DeserializeObject<Challenge>(content);
                title = tmp.Title;
            }
            return title;
        }
        public async Task<string> GetDescription(string authKey)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", authKey);
            var response = await client.GetAsync(RestUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var tmp = JsonConvert.DeserializeObject<Challenge>(content);
                description = tmp.Description;
            }
            return description;
        }
    }    
}
