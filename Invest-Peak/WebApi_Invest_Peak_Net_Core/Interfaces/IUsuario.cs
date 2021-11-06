using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Invest_Peak_Net_Core.Models;
using WebApi_Invest_Peak_Net_Core.ViewModels;

namespace WebApi_Invest_Peak_Net_Core.Interfaces
{
    public interface IUsuario
    {
        /// <summary>
        /// Método para buscar uma lista de usuário.
        /// </summary>
        List<Usuario> get();

        /// <summary>
        /// Método para cadastrar um novo usuário
        /// </summary>
        string post(UsuarioViewModel usuario);
        /// <summary>
        /// Método para buscar um usuário pelo seu id.
        /// </summary>
        Usuario getById(int id);

        /// <summary>
        /// Método para atualizar um usuário existente.
        /// </summary>
        void put(Usuario novoUsuario);

        /// <summary>
        /// Método para deletar um usuário.
        /// </summary>
        void delete(int id);
    }
}
