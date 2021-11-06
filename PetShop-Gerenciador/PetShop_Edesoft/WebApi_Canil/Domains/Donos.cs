using System;
using System.Collections.Generic;

namespace WebApi_Canil.Domains
{
    public partial class Donos
    {
        public Donos()
        {
            CaesDono = new HashSet<CaesDono>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<CaesDono> CaesDono { get; set; }
    }
}
