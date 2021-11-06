using Be3_Gerenciador.Domains;
using Be3_Gerenciador.Interfaces;
using Be3_Gerenciador.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Be3_Gerenciador.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPacientes _pacientes;

        public HomeController(IPacientes pacientes)
        {
            _pacientes = pacientes;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            Pacientes paciente = new Pacientes();

            try
            {
                paciente.Prontuario = form["prontuario"];
                paciente.Nome = form["nome"];
                paciente.Sobrenome = form["sobrenome"];
                paciente.DataDeNascimento = Convert.ToDateTime(form["data"]);
                paciente.Genero = form["genero"];
                paciente.Cpf = form["cpf"];
                paciente.Rg = form["rg"];
                paciente.Uf = form["uf"];
                paciente.Email = form["email"];
                paciente.Celular = form["celular"];
                paciente.Telefone = form["telefone"];
                paciente.Convenio = form["convenio"];
                paciente.CarterinhaDoConvenio = form["carteirinha"];
                paciente.ValidadeDaCarteirinha = Convert.ToDateTime(form["validade"]);


                _pacientes.post(paciente);
                return View();
            }
            catch (Exception)
            {
                ViewBag.mensagem = "Falha";
                return View();
            }
        }
    }
}
