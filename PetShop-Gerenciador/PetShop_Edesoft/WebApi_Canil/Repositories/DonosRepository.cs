using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Canil.Domains;
using WebApi_Canil.Interfaces;

namespace WebApi_Canil.Repositories
{
    public class DonosRepository : IDonos
    {
        private readonly CanilContext _context;
        public DonosRepository(CanilContext context)
        {
            _context = context;
        }
        public void delete(int id)
        {
            var dono = getById(id);
            if (dono != null)
                _context.Donos.Remove(dono);
            _context.SaveChanges();
        }

        public List<Donos> get()
        {
            return _context.Donos.ToList();
        }

        public Donos getById(int id)
        {
            return _context.Donos.FirstOrDefault(x => x.Id == id);
        }

        public void post(Donos dono)
        {
            _context.Donos.Add(dono);
            _context.SaveChanges();
        }

        public void update(int id, Donos dono)
        {
            var donoDb = getById(id);

            donoDb.Nome = (dono.Nome == null || dono.Nome == "") ? donoDb.Nome : dono.Nome;

            _context.Donos.Update(donoDb);
            _context.SaveChanges();
        }
    }
}
