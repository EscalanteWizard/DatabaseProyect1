using apiSistemaMatricula.Context;
using apiSistemaMatricula.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiSistemaMatricula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly AppDbContext context;
        public EstudiantesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<EstudiantesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EstudiantesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EstudiantesController>
        [HttpPost]
        public void Post([FromBody] Estudiantes estudiante)
        {
            if (ModelState.IsValid)
            {
                SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection(); //nombre de la conexion
                SqlCommand comando = conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
                conexion.Open(); //apertura de la conexión
                comando.CommandType = System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
                comando.CommandText = "registro_estudiante";  //variable del texto del comando que se va a llamar a través de la conexión

                comando.Parameters.Add("@cedula", System.Data.SqlDbType.Int).Value = estudiante.cedula;
                comando.Parameters.Add("@cedula_padre", System.Data.SqlDbType.Int).Value = estudiante.cedula_padre;
                comando.Parameters.Add("@grado", System.Data.SqlDbType.Int).Value = estudiante.numero_grado;

                comando.ExecuteNonQuery();

                conexion.Close(); //cierre de la conexión
            }
        }

        // PUT api/<EstudiantesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
