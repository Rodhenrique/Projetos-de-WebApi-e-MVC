using Redeservice_WebApi.Context;
using Redeservice_WebApi.Interfaces;
using Redeservice_WebApi.Models;
using Redeservice_WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Redeservice_WebApi.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly ContextService _context;
        public UsuarioRepository(ContextService context)
        {
            _context = context;
        }
        public void delete(int id)
        {
            var user = getById(id);
            if (user != null)
                _context.Usuarios.Remove(user);
            _context.SaveChanges();
        }

        public List<Usuario> get()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario getById(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.id == id);
        }

        public void post(UsuarioViewModel Usuario)
        {
            Usuario usuario = new Usuario();
            usuario.email = Usuario.email;
            usuario.nome = Usuario.nome;
            usuario.senha = Usuario.senha;
            usuario.cep = Usuario.cep;


            var endereco = ConsultarCep(usuario.cep);

            usuario.logradouro = endereco.Result.logradouro;
            usuario.bairro = endereco.Result.bairro;
            usuario.localidade = endereco.Result.localidade;
            usuario.casa_num = Usuario.casa_num;

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

        }

        public void update(int id, Usuario Usuario)
        {
            Usuario user = getById(id);
            Usuario.email = (Usuario.email == "")? user.email : Usuario.email;
            Usuario.nome = (Usuario.nome == "") ? user.nome : Usuario.nome;
            Usuario.senha = (Usuario.senha == "") ? user.senha : Usuario.senha;
            Usuario.cep = (Usuario.cep == "") ? user.cep : Usuario.cep;

            Usuario.logradouro = (Usuario.logradouro == "") ? user.logradouro : Usuario.logradouro;
            Usuario.bairro = (Usuario.bairro == "") ? user.bairro : Usuario.bairro;
            Usuario.localidade = (Usuario.localidade == "") ? user.localidade : Usuario.localidade;
            Usuario.casa_num = (Usuario.casa_num == 0) ? user.casa_num : Usuario.casa_num;

            _context.Usuarios.Update(Usuario);
            _context.SaveChanges();
        }

        private async Task<Usuario> ConsultarCep(string cep)
        {
            Usuario usuario = new Usuario();
            HttpClient cliente = new HttpClient();
            var resposta = await cliente.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            usuario = await resposta.Content.ReadAsAsync<Usuario>();

            return usuario;
        }
    }
}
