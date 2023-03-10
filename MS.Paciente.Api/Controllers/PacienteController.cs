using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using MS.Paciente.Api.Routes;
using MS.Paciente.Aplicacion.Paciente.Read;
using MS.Paciente.Dominio.Servicios;
using static MS.Paciente.Api.Routes.ApiRoutes;
using dominio = MS.Paciente.Dominio.Entidades;

namespace MS.Paciente.Api.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private PacienteQueryAll db = new PacienteQueryAll();



        [HttpGet(RoutePaciente.GetAll)]
        public IEnumerable<dominio.Paciente> ListarPaciente()
        {

            var listaPaciente = db.ListarPacientes();

            return listaPaciente;
        }


        [HttpGet(RoutePaciente.GetById)]
        public dominio.Paciente BuscarPaciente(int id)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("MsPacientes");
            var collection = database.GetCollection<dominio.Paciente>("Paciente");
            #endregion

            var objPaciente = collection.Find(x => x.idPac == id).FirstOrDefault();

            return objPaciente;
        }

        [HttpPost(RoutePaciente.Create)]
        public ActionResult<dominio.Paciente> CrearPaciente(dominio.Paciente Paciente)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("MsPacientes");
            var collection = database.GetCollection<dominio.Paciente>("Paciente");
            #endregion

            Paciente._id = ObjectId.GenerateNewId().ToString();
            collection.InsertOne(Paciente);
         
            return Ok();
        }

        [HttpPut(RoutePaciente.Update)]
        public ActionResult<dominio.Paciente> ModificarPaciente(int id, dominio.Paciente paciente)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("MsPacientes");
            var collection = database.GetCollection<dominio.Paciente>("Paciente");
            #endregion

            var objPaciente = collection.Find(x => x.idPac == id).FirstOrDefault();


            if (objPaciente != null)
            {
                objPaciente._id = paciente._id;
                objPaciente.idPac = paciente.idPac;
                objPaciente.Nombre = paciente.Nombre;
                objPaciente.apepa = paciente.apepa;
                objPaciente.apema = paciente.apema;
                objPaciente.edad = paciente.edad;
                objPaciente.seguro = paciente.seguro;
                objPaciente.Fecha_ingreso = paciente.Fecha_ingreso;

                collection.ReplaceOne(x => x.idPac == objPaciente.idPac, objPaciente);
            }


            return objPaciente;
        }

        [HttpDelete(RoutePaciente.Delete)]
        public ActionResult<dominio.Paciente> EliminarPaciente(int id)
        {
            #region Conexión a base de datos
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("MsPacientes");
            var collection = database.GetCollection<dominio.Paciente>("Paciente");
            #endregion

            collection.FindOneAndDelete(x => x.idPac == id);
            
            return Ok(id);
        }
    }
}
