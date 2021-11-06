using Be3_Gerenciador.Domains;
using Be3_Gerenciador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Be3_Gerenciador.Repositories
{
    public class PacientesRepository : IPacientes
    {

        private readonly DBContext _context;
        public PacientesRepository(DBContext context)
        {
            _context = context;
        }
        public void delete(int id)
        {
            var paciente = getById(id);
            if (paciente != null)
                _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
        }

        public List<Pacientes> get()
        {
            return _context.Pacientes.ToList();
        }

        public bool getByCpf(string cpf)
        {
            return _context.Pacientes.FirstOrDefault(x => x.Cpf == cpf) != null;
        }

        public Pacientes getById(int id)
        {
            return _context.Pacientes.FirstOrDefault(x => x.Id == id);
        }

        public void post(Pacientes paciente)
        {
            if(!getByCpf(paciente.Cpf))
            {
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
            }
        }

        public void update(int id, Pacientes pacienteNovo)
        {
            Pacientes paciente = getById(id);
            paciente.Prontuario = (pacienteNovo.Prontuario == "" && pacienteNovo.Prontuario == null) ? paciente.Prontuario : pacienteNovo.Prontuario;
            paciente.Nome = (pacienteNovo.Nome == "" && pacienteNovo.Nome == null) ? paciente.Nome : pacienteNovo.Nome;
            paciente.Genero = (pacienteNovo.Genero == "" && pacienteNovo.Genero == null) ? paciente.Genero : pacienteNovo.Genero;
            paciente.Sobrenome = (pacienteNovo.Sobrenome == "" && pacienteNovo.Sobrenome == null) ? pacienteNovo.Sobrenome : pacienteNovo.Sobrenome;
            paciente.DataDeNascimento = (pacienteNovo.DataDeNascimento == null) ? paciente.DataDeNascimento : pacienteNovo.DataDeNascimento;
            paciente.Cpf = (pacienteNovo.Cpf == "" && pacienteNovo.Cpf == null) ? paciente.Cpf : pacienteNovo.Cpf;
            paciente.Rg = (pacienteNovo.Rg == "" && pacienteNovo.Rg == null) ? paciente.Rg : pacienteNovo.Rg;
            paciente.Uf = (pacienteNovo.Uf == "" && pacienteNovo.Uf == null) ? paciente.Uf : pacienteNovo.Uf;
            paciente.Email = (pacienteNovo.Email == "" && pacienteNovo.Email == null) ? paciente.Email : pacienteNovo.Email;
            paciente.Celular = (pacienteNovo.Celular == "" && pacienteNovo.Celular == null) ? paciente.Celular : pacienteNovo.Celular;
            paciente.Telefone = (pacienteNovo.Telefone == "" && pacienteNovo.Telefone == null) ? paciente.Telefone : pacienteNovo.Telefone;
            paciente.Convenio = (pacienteNovo.Convenio == "" && pacienteNovo.Convenio == null) ? paciente.Convenio : paciente.Convenio;
            paciente.CarterinhaDoConvenio = (pacienteNovo.CarterinhaDoConvenio == "" && pacienteNovo.CarterinhaDoConvenio != null) ? paciente.CarterinhaDoConvenio : pacienteNovo.CarterinhaDoConvenio;
            paciente.ValidadeDaCarteirinha = (pacienteNovo.ValidadeDaCarteirinha == null) ? paciente.ValidadeDaCarteirinha : pacienteNovo.ValidadeDaCarteirinha;

            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }
    }
}
