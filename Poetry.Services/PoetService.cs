using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poetry.DTO.Models;
using Poetry.EF;
using AutoMapper;

namespace Poetry.Services
{
    public class PoetService : IPoetService
    {
        public IEnumerable<PoetDTO> GetPoets()
        {
            using (var db = new PoetryContext())
            {
                var poets = db.POET.ToList();
                var poetDTOs = poets.Select(p => Mapper.Map<Poet, PoetDTO>(p));
                return poetDTOs;
            };
        }

        public PoetDTO AddPoet(PoetDTO poet)
        {
            using (var db = new PoetryContext())
            {
                var poetEntity = Mapper.Map<PoetDTO, Poet>(poet);
                db.POET.Add(poetEntity);
                db.SaveChanges();

                return Mapper.Map<Poet, PoetDTO>(poetEntity);
            }
        }

        public PoetDTO GetPoet(int id)
        {
            using (var db = new PoetryContext())
            {
                var poetEntity = db.POET.Find(id);
                if (poetEntity != null)
                {
                    return Mapper.Map<Poet, PoetDTO>(poetEntity);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
