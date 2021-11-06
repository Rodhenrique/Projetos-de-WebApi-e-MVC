using Redeservice_WebApi.Models;
using Redeservice_WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redeservice_WebApi.Interfaces
{
    public interface IUsuario
    {
        List<Usuario> get();

        Usuario getById(int id);

        void post(UsuarioViewModel Usuario);
     
        void update(int id, Usuario Usuario);

        void delete(int id);
    }
}
