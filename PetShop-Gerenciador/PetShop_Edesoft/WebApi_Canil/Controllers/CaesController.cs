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
    public class CaesController : ControllerBase
    {
        private readonly ICaes _caes;

        public CaesController(ICaes caes)
        {
            _caes = caes;
        }

        [HttpGet]
        public IActionResult get()
        {
            var buscar = _caes.get();
            if (buscar.Count != 0)
            {
                return Ok(buscar);
            }
            else
            {
                return NotFound("Nenhum cão encontrado!!!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            try
            {
                var buscar = _caes.getById(id);
                if (buscar != null)
                {
                    return Ok(buscar);
                }
                else
                {
                    return StatusCode(400, "Erro ao buscar um cão!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(400, "Erro ao buscar um cão!!!");
            }
        }

        [HttpPost]
        public IActionResult post(Caes caes)
        {
            try
            {
                if (caes != null && caes.Apelido != "")
                {  
                    _caes.post(caes);
                    return StatusCode(201, "Cão cadastrado com sucesso!!!");
                }
                else
                {
                    return StatusCode(400, "Erro com formato de dados recebido!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(400, "Ocorreu um erro!!!");
            }
        }

        [HttpPut]
        public IActionResult put(Caes caes)
        {
            try
            {
                var buscar = _caes.getById(caes.Id);
                if (buscar != null)
                {
                    _caes.update(caes.Id, caes);
                    return StatusCode(202, "Cão atualizado com sucesso!!!");
                }
                else
                {
                    return StatusCode(400, "Erro ao atualizar um cão!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(400, "Erro ao atualizar um cão!!!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            try
            {
                var buscar = _caes.getById(id);
                if (buscar != null)
                {
                    _caes.delete(id);
                    return StatusCode(202, "Cão deletado com sucesso!!!");
                }
                else
                {
                    return StatusCode(403, "Erro ao deletar um cão!!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(403, "Erro ao deletar um cão!!!");
            }
        }
    }
}
