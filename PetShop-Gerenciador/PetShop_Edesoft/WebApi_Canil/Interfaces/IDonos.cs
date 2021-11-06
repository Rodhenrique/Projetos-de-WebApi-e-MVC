using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Canil.Domains;

namespace WebApi_Canil.Interfaces
{
    public interface IDonos
    {
        List<Donos> get();

        Donos getById(int id);

        void post(Donos dono);

        void update(int id, Donos dono);

        void delete(int id);
    }
}
