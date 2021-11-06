using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Canil.Domains;
using WebApi_Canil.ViewsModels;

namespace WebApi_Canil.Interfaces
{
    public interface ICaesDono
    {
        List<CaesDono> get();

        CaesDono getById(int id);

        void post(CaesDonoViewModel caesDono);
        void postById(CaesDono caesDono);


        void update(int id, CaesDono caesDono);

        void delete(int id);
    }
}
