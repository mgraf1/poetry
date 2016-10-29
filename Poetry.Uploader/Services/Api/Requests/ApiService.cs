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
            HttpClient client = _setupWebClient();
            var requestTaskResult = await client.GetAsync(apiArgs);
            requestTaskResult.EnsureSuccessStatusCode();
            return await requestTaskResult.Content.ReadAsStringAsync();
        }

        public async Task<string> PostRequestAsync(string apiArgs, string jsonContent)
        {
            HttpClient client = _setupWebClient();
            var content = new StringContent(jsonContent, Encoding.Default, ACCEPT_HEADER);
            var requestTaskResult = await client.PostAsync(apiArgs, content);
            requestTaskResult.EnsureSuccessStatusCode();
            return await requestTaskResult.Content.ReadAsStringAsync();
        }

        private HttpClient _setupWebClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ACCEPT_HEADER));
            return client;
        }
    }
}
