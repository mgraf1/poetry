using AutoMapper;
using Poetry.DTO.Models;
using Poetry.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.DTO
{
    public static class AutoMapperDTOConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Poet, PoetDTO>().ReverseMap();
            });
        }
    }
}
