using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redeservice_WebApi.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string cep { get; set; }
        public string localidade { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public int casa_num { get; set; }
    }
}
