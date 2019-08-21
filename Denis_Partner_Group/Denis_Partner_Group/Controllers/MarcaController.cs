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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class MarcaController : Controller
    {
        private IMarcaRepository MarcaRepository { get; set; }

        public MarcaController()
        {
            MarcaRepository = new MarcaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(MarcaRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(MarcaDomain marca)
        {
            try
            {
                MarcaRepository.Cadastrar(marca);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}