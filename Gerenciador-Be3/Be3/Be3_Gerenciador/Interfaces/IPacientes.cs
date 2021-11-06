using Be3_Gerenciador.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Be3_Gerenciador.Interfaces
{
    public interface IPacientes
    {
        List<Pacientes> get();

        Pacientes getById(int id);

        bool getByCpf(string cpf);

        void post(Pacientes paciente);

        void update(int id, Pacientes paciente);

        void delete(int id);

    }
}
