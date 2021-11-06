using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Canil.Domains;
using WebApi_Canil.Interfaces;
using WebApi_Canil.ViewsModels;

namespace WebApi_Canil.Repositories
{
    public class CaesDonoRepository : ICaesDono
    {
        private readonly CanilContext _context;
        public CaesDonoRepository(CanilContext context)
        {
            _context = context;
        }

        public void delete(int id)
        {
            var caesDono = getById(id);
            if (caesDono != null)
                _context.CaesDono.Remove(caesDono);
            _context.SaveChanges();
        }

        public List<CaesDono> get()
        {
            return _context.CaesDono.Include(x => x.IdCaoNavigation).Include(x => x.IdCaoNavigation.IdRacaNavigation).Include(x => x.IdDonoNavigation).ToList();
        }

        public CaesDono getById(int id)
        {
            return _context.CaesDono.Include(x => x.IdCaoNavigation).FirstOrDefault(x => x.Id == id);
        }

        public void post(CaesDonoViewModel caesDono)
        {
            CaesDono caes = new CaesDono();
            caes.IdCaoNavigation = new Caes { Apelido = caesDono.apelido };
            caes.IdDonoNavigation = new Donos { Nome = caesDono.nome };

            caes.IdCaoNavigation.IdRaca = caesDono.idRaca;

            _context.CaesDono.Add(caes);

            _context.SaveChanges();
        }

        public void postById(CaesDono caesDono)
        {
            _context.CaesDono.Add(caesDono);

            _context.SaveChanges();
        }

        public void update(int id, CaesDono caesDono)
        {
             var dono = getById(id);
             dono = caesDono;
            _context.CaesDono.Update(dono);
            _context.SaveChanges();
        }
    }
}
