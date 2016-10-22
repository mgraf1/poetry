using Poetry.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.Services.Api
{
    public interface IPoetService
    {
        Task<IEnumerable<PoetDTO>> GetAllPoets();

        Task<PoetDTO> GetPoet(int id);

        PoetDTO AddPoet(PoetDTO poet);
    }
}
