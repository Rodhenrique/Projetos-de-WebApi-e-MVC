using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Canil.Domains;
using WebApi_Canil.Interfaces;
using WebApi_Canil.ViewsModels;

namespace WebApi_Canil.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CaesDonoController : ControllerBase
    {
        private readonly ICaesDono _caesDono;

        public CaesDonoController(ICaesDono caes)
        {
            _caesDono = caes;
        }

        [HttpGet]
        public IActionResult get()
        {
            var buscar = _caesDono.get();
            if (buscar.Count != 0)
            {
                return Ok(buscar);
            }
            else
            {
                return NotFound("Nenhum cadastro encontrado!!!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            try
            {
                var buscar = _caesDono.getById(id);
                if (buscar != null)
                {
                    return Ok(buscar);
                }
                else
                {
                    return StatusCode(400, "Erro ao buscar um cadastro!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(400, "Erro ao buscar um cadastro!!!");
            }
        }

        [HttpPost]
        public IActionResult post(CaesDonoViewModel caesDono)
        {
            try
            {
                if (caesDono != null && caesDono.nome != "" && caesDono.apelido != "")
                {   
                    _caesDono.post(caesDono);
                    return StatusCode(201, "Cadastro criado com sucesso!!!");
                }
                else
                {
                    return StatusCode(400, "Erro com formato de dados recebido!!!");
                }
            }
            catch (Exception e )
            {
                return StatusCode(400, e);               
            }
        }

        [HttpPost("PostById")]
        public IActionResult postById(CaesDono caesDono)
        {
            try
            {
                if (caesDono != null && caesDono.IdCao != 0 && caesDono.IdDono != 0)
                {
                    _caesDono.postById(caesDono);
                    return StatusCode(201, "Cadastro criado com sucesso!!!");
                }
                else
                {
                    return StatusCode(400, "Erro com formato de dados recebido!!!");
                }
            }
            catch (Exception e)
            {
                return StatusCode(400, e);
            }
        }

        [HttpPut]
        public IActionResult put(CaesDono caesDono)
        {
            try
            {
                var buscar = _caesDono.getById(caesDono.Id);
                if (buscar != null)
                {
                    _caesDono.update(caesDono.Id, caesDono);
                    return StatusCode(202, "cadastro atualizado com sucesso!!!");
                }
                else
                {
                    return StatusCode(400, "Erro ao atualizar cadastro!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(400, "Erro ao atualizar cadastro!!!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            try
            {
                var buscar = _caesDono.getById(id);
                if (buscar != null)
                {
                    _caesDono.delete(id);
                    return StatusCode(202, "Cadsatro deletado com sucesso!!!");
                }
                else
                {
                    return StatusCode(403, "Erro ao deletar cadastro!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(403, "Erro ao deletar cadastro!!!");
            }
        }
    }
}
