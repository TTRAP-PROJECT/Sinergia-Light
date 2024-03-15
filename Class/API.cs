using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstMobileApp.Class
{
    class API
    {
        HttpClient _client;


        public API()
        {
            _client = new HttpClient();
        }
        public async Task<string> GetJsonFromApi(string url)
        {
            try
            {
                var response = await _client.GetStringAsync(url);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching JSON from API: {ex.Message}");
                return null;
            }
        }
        public async Task<string> GetPostData(string endpoint)
        {
            var url = "http://192.168.125.11:81/api"+endpoint;
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }
    }
}

