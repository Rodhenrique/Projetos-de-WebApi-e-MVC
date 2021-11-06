using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Invest_Peak_Net_Core.Interfaces;
using WebApi_Invest_Peak_Net_Core.Models;
using WebApi_Invest_Peak_Net_Core.ViewModels;

namespace WebApi_Invest_Peak_Net_Core.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private static List<Usuario> ListUsuarios = new List<Usuario>();

        /// <summary>
        /// Método para deletar um usuário.
        /// </summary>
        public void delete(int id)
        {
            Usuario userDelete = ListUsuarios.FirstOrDefault(u => u.id == id);
            if (userDelete != null)
            {
                ListUsuarios.Remove(userDelete);
            }
        }

        /// <summary>
        /// Método para buscar uma lista de usuário.
        /// </summary>
        public List<Usuario> get()
        {
            return ListUsuarios;
        }

        /// <summary>
        /// Método para buscar um usuário pelo seu id.
        /// </summary>
        public Usuario getById(int id)
        {
            return ListUsuarios.FirstOrDefault(u => u.id == id);
        }

        /// <summary>
        /// Método para cadastrar um novo usuário
        /// </summary>
        public string post(UsuarioViewModel novoUsuario)
        {
            if (novoUsuario.nome != "" && novoUsuario.nome != null)
            {
                int idHigh = (ListUsuarios.Count == 0)? 0 : ListUsuarios.Max(u => u.id);
                Usuario usuario = new Usuario();
                usuario.nome = novoUsuario.nome;
                usuario.id = idHigh + 1;
                ListUsuarios.Add(usuario);

                int parcela = novoUsuario.parcelas;
                decimal valor = Convert.ToDecimal(novoUsuario.valor.ToString().Replace(".", "").Replace(",", ""));
                decimal total = (valor * parcela) + ((valor * parcela) * 5) / 100;

                return string.Format("{0:C}", total);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Método para atualizar um usuário existente.
        /// </summary>
        public void put(Usuario novoUsuario)
        {
            Usuario UserAtual = ListUsuarios.FirstOrDefault(u => u.id == novoUsuario.id);
            if (UserAtual != null)
            {
                int position = ListUsuarios.FindIndex(u => u.id == novoUsuario.id);
                ListUsuarios[position].nome = (novoUsuario.nome == "" || novoUsuario.nome == null)? UserAtual.nome: novoUsuario.nome;
            }
        }
    }
}
