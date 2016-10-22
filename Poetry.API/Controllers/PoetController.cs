using Poetry.DTO;
using Poetry.DTO.Models;
using Poetry.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Poetry.API.Controllers
{
    public class PoetController : ApiController
    {
        private IPoetService _poetService;

        public PoetController(IPoetService poetService)
        {
            _poetService = poetService;
        }

        [HttpGet]
        public IHttpActionResult GetPoet([FromUri]int id)
        {
            try
            {
                var poetDto = _poetService.GetPoet(id);
                if (poetDto != null)
                {
                    return Ok(poetDto);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllPoets()
        {
            try
            {
                var poetDtos = _poetService.GetPoets();
                return Ok(poetDtos);

            }
            catch(Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult AddPoet([FromBody]PoetDTO poet)
        {
            try
            {
                var poetToReturn = _poetService.AddPoet(poet);
                return Created(Request.RequestUri + "/" + poetToReturn.Id.ToString(), poetToReturn);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
        }
    }
}
