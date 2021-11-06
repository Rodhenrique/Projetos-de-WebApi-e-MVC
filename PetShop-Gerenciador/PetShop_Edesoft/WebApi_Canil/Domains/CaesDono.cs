using System;
using System.Collections.Generic;

namespace WebApi_Canil.Domains
{
    public partial class CaesDono
    {
        public int Id { get; set; }
        public int? IdCao { get; set; }
        public int? IdDono { get; set; }

        public Caes IdCaoNavigation { get; set; }
        public Donos IdDonoNavigation { get; set; }
    }
}
