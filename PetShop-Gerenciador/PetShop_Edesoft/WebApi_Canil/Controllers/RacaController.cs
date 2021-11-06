using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Canil.Domains;
using WebApi_Canil.Interfaces;

namespace WebApi_Canil.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RacaController : ControllerBase
    {
        private readonly IRaca _raca;

        public RacaController(IRaca raca)
        {
            _raca = raca;
        }

        [HttpGet]
        public IActionResult get()
        {
            var buscar = _raca.get();
            if (buscar.Count != 0)
            {
                return Ok(buscar);
            }
            else
            {
                return NotFound("Nenhuma raça encontrada!!!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            try
            {
                var buscar = _raca.getById(id);
                if (buscar != null)
                {
                    return Ok(buscar);
                }
                else
                {
                    return StatusCode(400, "Erro ao buscar uma raça!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(400, "Erro ao buscar uma raça!!!");
            }
        }

        [HttpPost]
        public IActionResult post(Raca raca)
        {
            try
            {
                if (raca != null && raca.Titulo != "")
                {
                    _raca.post(raca);
                    return StatusCode(201, "Raça criado com sucesso!!!");
                }
                else
                {
                    return StatusCode(400, "Erro com formato de dados recebido!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(400, "Erro ao cadastrar uma raça!!!");
            }
        }

        [HttpPut]
        public IActionResult put(Raca raca)
        {
            try
            {
                var buscar = _raca.getById(raca.Id);
                if (buscar != null)
                {
                    _raca.update(raca.Id, raca);
                    return StatusCode(202, "Raça atualizado com sucesso!!!");
                }
                else
                {
                    return StatusCode(400, "Erro ao atualizar raça!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(400, "Erro ao atualizar raça!!!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            try
            {
                var buscar = _raca.getById(id);
                if (buscar != null)
                {
                    _raca.delete(id);
                    return StatusCode(202, "Raça deletado com sucesso!!!");
                }
                else
                {
                    return StatusCode(403, "Erro ao deletar raça!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(403, "Erro ao deletar raça!!!");
            }
        }
    }
}
