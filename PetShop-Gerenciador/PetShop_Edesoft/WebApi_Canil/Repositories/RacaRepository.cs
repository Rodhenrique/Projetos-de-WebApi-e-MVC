using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Canil.Domains;
using WebApi_Canil.Interfaces;

namespace WebApi_Canil.Repositories
{
    public class RacaRepository : IRaca
    {
        private readonly CanilContext _context;
        public RacaRepository(CanilContext context)
        {
            _context = context;
        }
        public void delete(int id)
        {
            var raca = getById(id);
            if (raca != null)
                _context.Raca.Remove(raca);
            _context.SaveChanges();
        }

        public List<Raca> get()
        {
            return _context.Raca.ToList();
        }

        public Raca getById(int id)
        {
            return _context.Raca.FirstOrDefault(x => x.Id == id);
        }

        public void post(Raca raca)
        {
            _context.Raca.Add(raca);
            _context.SaveChanges();
        }

        public void update(int id, Raca raca)
        {
            var racaDB = getById(id);

            racaDB.Titulo = (raca.Titulo == null || raca.Titulo == "") ? racaDB.Titulo : raca.Titulo;

            _context.Raca.Update(racaDB);
            _context.SaveChanges();
        }
    }
}
