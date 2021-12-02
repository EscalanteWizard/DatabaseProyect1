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
    public class ProfesoresGrupoController : ControllerBase
    {
        private readonly AppDbContext context;
        public ProfesoresGrupoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<GruposController>
        [HttpGet]
        public ActionResult Get()
        {
             try
            {                
                SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection(); //nombre de la conexion
                SqlCommand comando = conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
                conexion.Open(); //apertura de la conexión
                comando.CommandType = System.Data.CommandType.Text;  //se define que el comando el del tipo procedimiento almacenado
                comando.CommandText = ""; //verificar disponibilidad del procedimiento**********
                comando.ExecuteNonQuery();
                conexion.Close();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
        // POST api/<GruposController>
        [HttpPost]
        public ActionResult Post([FromBody] ProfesoresGrupo profesorGrupo )
        {
            try
            {
                if (ModelState.IsValid) {
                    SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection(); //nombre de la conexion
                    SqlCommand comando = conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
                    conexion.Open(); //apertura de la conexión
                    comando.CommandType = System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
                    comando.CommandText = "registro_profesor_grupo";  //variable del texto del comando que se va a llamar a través de la conexión

                    comando.Parameters.Add("@numero_periodo", System.Data.SqlDbType.Int).Value = profesorGrupo.numero_periodo;
                    comando.Parameters.Add("@anho_periodo", System.Data.SqlDbType.Int).Value = profesorGrupo.anho_periodo;
                    comando.Parameters.Add("@materia", System.Data.SqlDbType.VarChar,50).Value = profesorGrupo.materia;
                    comando.Parameters.Add("@grado", System.Data.SqlDbType.Int).Value = profesorGrupo.grado;
                    comando.Parameters.Add("@grupo", System.Data.SqlDbType.VarChar, 50).Value = profesorGrupo.grupo;
                    comando.Parameters.Add("@cedula", System.Data.SqlDbType.Int).Value = profesorGrupo.cedula;
                    
                    comando.ExecuteNonQuery();
                    conexion.Close(); //cierre de la conexión
                    return Ok(usuario);
                }
                 else { return BadRequest(); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<GruposController>/5
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GruposController>/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
