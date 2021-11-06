using System;
using System.Collections.Generic;

namespace WebApi_Canil.Domains
{
    public partial class Caes
    {
        public Caes()
        {
            CaesDono = new HashSet<CaesDono>();
        }

        public int Id { get; set; }
        public string Apelido { get; set; }
        public int? IdRaca { get; set; }

        public Raca IdRacaNavigation { get; set; }
        public ICollection<CaesDono> CaesDono { get; set; }
    }
}
