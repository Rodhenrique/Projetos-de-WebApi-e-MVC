using Microsoft.AspNetCore.Mvc;
using Redeservice_WebApi.Interfaces;
using Redeservice_WebApi.Models;
using Redeservice_WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redeservice_WebApi.Controllers
{
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        public class UsuarioController : ControllerBase
        {
            private readonly IUsuario _usuario;

            public UsuarioController(IUsuario usuario)
            {
                _usuario = usuario;
            }

            [HttpGet]
            public IActionResult get()
            {
                var buscar = _usuario.get();
                if (buscar.Count != 0)
                {
                    return Ok(buscar);
                }
                else
                {
                    return NotFound("Nenhum usuário encontrado!!!");
                }
            }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var buscar = _usuario.getById(id);
            if (buscar != null)
            {
                return Ok(buscar);
            }
            else
            {
                return StatusCode(400, "Erro ao buscar um usuário!!!");
            }
        }

        [HttpPost]
        public IActionResult post(UsuarioViewModel usuario)
        {
            if (usuario != null && usuario.nome != "" && usuario.cep != "" && usuario.email != "")
            {
                _usuario.post(usuario);
                return StatusCode(201, "Usuário criado com sucesso!!!");
            }
            else
            {
                return StatusCode(400, "Erro com formato de dados recebido!!!");
            }
        }

        [HttpPut]
        public IActionResult put(Usuario putUser)
        {
            var buscar = _usuario.getById(putUser.id);
            if (buscar != null)
            {
                _usuario.update(putUser.id, putUser);
                return StatusCode(202, "Usuário atualizado com sucesso!!!");
            }
            else
            {
                return StatusCode(400, "Erro ao atualizar usuário!!!");
            }
        }
      
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            var buscar = _usuario.getById(id);
            if (buscar != null)
            {
                _usuario.delete(id);
                return StatusCode(202, "Usuário deletado com sucesso!!!");
            }
            else
            {
                return StatusCode(403, "Erro ao deletar usuário!!!");
            }
        }

    }
}
