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
    public class DonosController : ControllerBase
    {
        private readonly IDonos _donos;

        public DonosController(IDonos donos)
        {
            _donos = donos;
        }

        [HttpGet]
        public IActionResult get()
        {
            var buscar = _donos.get();
            if (buscar.Count != 0)
            {
                return Ok(buscar);
            }
            else
            {
                return NotFound("Nenhum dono encontrado!!!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            try
            {
                var buscar = _donos.getById(id);
                if (buscar != null)
                {
                    return Ok(buscar);
                }
                else
                {
                    return StatusCode(400, "Erro ao buscar um dono!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(400, "Erro ao buscar um dono!!!");
            }
        }

        [HttpPost]
        public IActionResult post(Donos donos)
        {
            try
            {
                if (donos != null && donos.Nome != "")
                {
                    _donos.post(donos);
                    return StatusCode(201, "Dono criado com sucesso!!!");
                }
                else
                {
                    return StatusCode(400, "Erro com formato de dados recebido!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(400, "Erro com cadastro do dono!!!");
            }
        }

        [HttpPut]
        public IActionResult put(Donos donos)
        {
            try
            {
                var buscar = _donos.getById(donos.Id);
                if (buscar != null)
                {
                    _donos.update(donos.Id, donos);
                    return StatusCode(202, "Dono atualizado com sucesso!!!");
                }
                else
                {
                    return StatusCode(400, "Erro ao atualizar dono!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(400, "Erro ao atualizar dono!!!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {

            try
            {
                var buscar = _donos.getById(id);
                if (buscar != null)
                {
                    _donos.delete(id);
                    return StatusCode(202, "Dono deletado com sucesso!!!");
                }
                else
                {
                    return StatusCode(403, "Erro ao deletar Dono!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(403, "Erro ao deletar Dono!!!");
            }
        }
    }
}
