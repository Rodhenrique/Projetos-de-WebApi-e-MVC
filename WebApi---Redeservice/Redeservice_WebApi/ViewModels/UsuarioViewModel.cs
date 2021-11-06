using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Redeservice_WebApi.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "É necessário informar um nome.")] 
        [DataType(DataType.Text)]
        public string nome { get; set; }
        [Required(ErrorMessage = "É necessário informar um email.")] 
        [DataType(DataType.EmailAddress)] 
        public string email { get; set; }
        [Required(ErrorMessage = "É necessário informar um senha.")] 
        [DataType(DataType.Password)] 
        public string senha { get; set; }
        [Required(ErrorMessage = "É necessário informar um cep.")] 
        [DataType(DataType.Text)] 
        public string cep { get; set; }

        public int casa_num { get; set; }

    }
}
