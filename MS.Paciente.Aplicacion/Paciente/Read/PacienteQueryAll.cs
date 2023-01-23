using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using MS.Paciente.Infraestructura.NewFolder;
using MS.Paciente.Infraestructura.NewFolder1;
using dominio = MS.Paciente.Dominio.Entidades;

namespace MS.Paciente.Aplicacion.Paciente.Read
{
    public class PacienteQueryAll
    {
        internal DBRepository _repository = new DBRepository();
        private IMongoCollection<dominio.Paciente> _paciente;

        public PacienteQueryAll()
        {
            _paciente = _repository.db.GetCollection<dominio.Paciente>("Paciente");
        }

        public IEnumerable<dominio.Paciente> ListarPacientes()
        {
            return _paciente.Find(x => true).ToList();
        }
    }
}
