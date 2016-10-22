using Poetry.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Services
{
    public interface IPoetService
    {
        IEnumerable<PoetDTO> GetPoets();

        PoetDTO GetPoet(int id);

         PoetDTO AddPoet(PoetDTO poet);
    }
}
