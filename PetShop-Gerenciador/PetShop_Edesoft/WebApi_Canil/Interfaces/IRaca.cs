using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Canil.Domains;

namespace WebApi_Canil.Interfaces
{
    public interface IRaca
    {
        List<Raca> get();

        Raca getById(int id);

        void post(Raca raca);

        void update(int id, Raca raca);

        void delete(int id);
    }
}
