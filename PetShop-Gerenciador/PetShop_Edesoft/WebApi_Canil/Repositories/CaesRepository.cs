using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Canil.Domains;
using WebApi_Canil.Interfaces;

namespace WebApi_Canil.Repositories
{
    public class CaesRepository : ICaes
    {
        private readonly CanilContext _context;
        public CaesRepository(CanilContext context)
        {
            _context = context;
        }
        public void delete(int id)
        {
            var cao = getById(id);
            if (cao != null)
                _context.Caes.Remove(cao);
            _context.SaveChanges();
        }

        public List<Caes> get()
        {
            return _context.Caes.ToList();
        }

        public Caes getById(int id)
        {
            return _context.Caes.FirstOrDefault(x => x.Id == id);
        }

        public void post(Caes cao)
        {
            _context.Caes.Add(cao);
            _context.SaveChanges();
        }

        public void update(int id, Caes caes)
        {
            var cao = getById(id);

            cao.Apelido = (caes.Apelido == null || caes.Apelido == "") ? cao.Apelido : caes.Apelido;
            cao.IdRaca = (caes.IdRaca == 0) ? cao.IdRaca : caes.IdRaca;

            _context.Caes.Update(cao);
            _context.SaveChanges();
        }
    }
}
