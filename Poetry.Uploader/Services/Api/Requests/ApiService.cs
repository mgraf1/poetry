using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.Services.Api.Requests
{
    public class ApiService : IApiService
    {
        private string API_URL = "http://localhost:59988";
        private string ACCEPT_HEADER = "application/json";

        public async Task<string> GetRequestAsync(string apiArgs)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ACCEPT_HEADER));

            var requestTaskResult = await client.GetAsync(apiArgs);
            requestTaskResult.EnsureSuccessStatusCode();
            var jsonString = await requestTaskResult.Content.ReadAsStringAsync();

            return jsonString;
        }
    }
}
