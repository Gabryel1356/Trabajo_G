using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Paciente.Dominio.Entidades
{
    [BsonIgnoreExtraElements]
    public class Paciente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int dni { get; set; }

        public string Nombre { get; set; }

        public string apepa { get; set; }

        public string apema { get; set; }
        public string edad { get; set; }
        public string seguro { get; set; }
        public string genero { get; set; }
        public string Fecha_ingreso { get; set; }

        public int idPac { get; set; }
    }
}
