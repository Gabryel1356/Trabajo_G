using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.Paciente.Infraestructura.NewFolder1;
using dominio = MS.Paciente.Dominio.Entidades;

namespace MS.Paciente.Dominio.Servicios
{

    public class PacienteService
    {
        private IMongoCollection<dominio.Paciente> _paciente;

        public PacienteService(IDBSettings dBSettings)
        {
            var cliente = new MongoClient(dBSettings.Server);
            var database = cliente.GetDatabase(dBSettings.Database);
            _paciente = database.GetCollection<dominio.Paciente>(dBSettings.Collection);
        }

        public List<dominio.Paciente> ListarPacientes()
        {
            return _paciente.Find(x => true).ToList();
        }
    }
}
