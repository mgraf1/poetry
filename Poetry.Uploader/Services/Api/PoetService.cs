using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poetry.DTO.Models;
using Poetry.Uploader.Services.Api.Requests;
using System.Web.Script.Serialization;

namespace Poetry.Uploader.Services.Api
{
    public class PoetService : IPoetService
    {
        private IApiService _apiService;

        public PoetService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<PoetDTO> AddPoet(PoetDTO poet)
        {
            string poetJson = new JavaScriptSerializer().Serialize(poet);
            string jsonResponse = await _apiService.PostRequestAsync("/api/poet", poetJson);
            return new JavaScriptSerializer().Deserialize<PoetDTO>(jsonResponse);
        }

        public async Task<IEnumerable<PoetDTO>> GetAllPoets()
        {
            string jsonResponse = await _apiService.GetRequestAsync("/api/poet");
            return new JavaScriptSerializer().Deserialize<IEnumerable<PoetDTO>>(jsonResponse);
        }

        public async Task<PoetDTO> GetPoet(int id)
        {
            string json = await _apiService.GetRequestAsync("/api/poet/" + id);
            return new JavaScriptSerializer().Deserialize<PoetDTO>(json);
        }
    }
}
