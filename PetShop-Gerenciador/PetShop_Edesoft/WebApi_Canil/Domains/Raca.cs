using System;
using System.Collections.Generic;

namespace WebApi_Canil.Domains
{
    public partial class Raca
    {
        public Raca()
        {
            Caes = new HashSet<Caes>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }

        public ICollection<Caes> Caes { get; set; }
    }
}
