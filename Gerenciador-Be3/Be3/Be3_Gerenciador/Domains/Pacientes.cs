using System;
using System.Collections.Generic;

namespace Be3_Gerenciador.Domains
{
    public partial class Pacientes
    {
        public int Id { get; set; }
        public string Prontuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Uf { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Convenio { get; set; }
        public string CarterinhaDoConvenio { get; set; }
        public DateTime? ValidadeDaCarteirinha { get; set; }
        public string Genero { get; set; }
    }
}
