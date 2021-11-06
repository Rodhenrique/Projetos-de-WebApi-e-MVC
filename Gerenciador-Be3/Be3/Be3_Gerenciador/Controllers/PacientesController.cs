using Be3_Gerenciador.Domains;
using Be3_Gerenciador.Interfaces;
using Be3_Gerenciador.Repositories;
using Be3_Gerenciador.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Be3_Gerenciador.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacientes _pacientes;

        public PacientesController(IPacientes pacientes)
        {
            _pacientes = pacientes;
        }
        public IActionResult Index()
        {
            return View(new PacientesViewModel() { pacientes = _pacientes.get()});
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {

            Pacientes paciente = new Pacientes();

            try
            {
                paciente.Id = Convert.ToInt32(form["identificator"]);

                paciente.Prontuario = form["prontuario"];
                paciente.Nome = form["nome"];
                paciente.Sobrenome = form["sobrenome"];
                paciente.DataDeNascimento = Convert.ToDateTime(form["data"]);
                // paciente.s = form["nome"];
                paciente.Cpf = form["cpf"];
                paciente.Rg = form["rg"];
                paciente.Uf = form["uf"];
                paciente.Email = form["email"];
                paciente.Celular = form["celular"];
                paciente.Telefone = form["telefone"];
                paciente.Convenio = form["convenio"];
                paciente.CarterinhaDoConvenio = form["carteirinha"];
                paciente.ValidadeDaCarteirinha = Convert.ToDateTime(form["validade"]);


                _pacientes.update(paciente.Id,paciente);
                return RedirectToAction("Index", "Pacientes");
            }
            catch (Exception)
            {
                return RedirectToAction("Index","Pacientes");
            }
        }
    }
}
