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
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext context;
        public UsuariosController(AppDbContext context)
        {
            this.context = context;
        }
        /** GET: api/<UsuariosController>
        [HttpGet]
        public ActionResult Get()
        {
            try {
                return Ok(context.Usuario.ToList());
            } catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }**/

        /**public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }**/

        // GET api/<UsuariosController>/5
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                //var usuario = context.Usuario.FirstOrDefault(g => g.cedula == id);
                //return Ok(usuario);
                SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection(); //nombre de la conexion
                SqlCommand comando = conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
                conexion.Open(); //apertura de la conexión
                comando.CommandType = System.Data.CommandType.Text;  //se define que el comando el del tipo procedimiento almacenado
                comando.CommandText = "informacionUsuarios";
                comando.ExecuteNonQuery();
                conexion.Close();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsuariosController>
        /**[HttpPost]
        public ActionResult Post([FromBody] Usuarios usuario)
        {
            try
            {
                context.Usuario.Add(usuario);
                context.SaveChanges();
                return CreatedAtRoute("GetUsuario", new {id = usuario.cedula}, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }**/

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult HOLA([FromBody] Usuarios usuario)
        {
            try
            {
                if (ModelState.IsValid) {
                    SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection(); //nombre de la conexion
                    SqlCommand comando = conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
                    conexion.Open(); //apertura de la conexión
                    comando.CommandType = System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
                    comando.CommandText = "registrar_usuario";  //variable del texto del comando que se va a llamar a través de la conexión

                    comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 50).Value = usuario.nombre;
                    comando.Parameters.Add("@cedula", System.Data.SqlDbType.Int).Value = usuario.cedula;
                    comando.Parameters.Add("@telefono", System.Data.SqlDbType.Int).Value = usuario.telefono;
                    comando.Parameters.Add("@ciudad", System.Data.SqlDbType.VarChar, 50).Value = usuario.ciudad;
                    comando.Parameters.Add("@canton", System.Data.SqlDbType.VarChar, 50).Value = usuario.canton;
                    comando.Parameters.Add("@fecha_nacimiento", System.Data.SqlDbType.Date).Value = usuario.fecha_nacimiento;
                    comando.Parameters.Add("@fecha_creacion", System.Data.SqlDbType.Date).Value = usuario.fecha_creacion;
                    comando.Parameters.Add("@sexo", System.Data.SqlDbType.VarChar, 50).Value = usuario.sexo;
                    comando.Parameters.Add("@passw", System.Data.SqlDbType.VarChar, 50).Value = usuario.passw;
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

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuarios usuario)
        {
            try
            {
                if (usuario.cedula == id)
                {
                    context.Entry(usuario).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetUsuario", new { id = usuario.cedula }, usuario);
                }
                else {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var usuario = context.Usuario.FirstOrDefault(g => g.cedula == id);
                if (usuario != null)
                {
                    context.Usuario.Remove(usuario);
                    context.SaveChanges();
                    return Ok(id);
                }
                else {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
