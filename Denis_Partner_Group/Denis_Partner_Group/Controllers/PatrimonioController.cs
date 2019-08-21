using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Denis_Partner_Group.Domains;
using Denis_Partner_Group.Interfaces;
using Denis_Partner_Group.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Denis_Partner_Group.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrimonioController : ControllerBase
    {
        private IPatrimonioRepository PatrimonioRepository { get; set; }

        public PatrimonioController()
        {
            PatrimonioRepository = new PatrimonioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(PatrimonioRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(PatrimonioDomain patrimonio)
        {
            try
            {
                PatrimonioRepository.Cadastrar(patrimonio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}