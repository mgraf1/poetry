using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.Services.Api.Requests
{
    public interface IApiService
    {
        Task<string> GetRequestAsync(string apiArgs);
    }
}
