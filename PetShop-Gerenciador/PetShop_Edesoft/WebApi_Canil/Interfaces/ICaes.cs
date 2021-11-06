using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Canil.Domains;

namespace WebApi_Canil.Interfaces
{
    public interface ICaes
    {
        List<Caes> get();

        Caes getById(int id);

        void post(Caes cao);

        void update(int id, Caes caes);

        void delete(int id);
    }
}
