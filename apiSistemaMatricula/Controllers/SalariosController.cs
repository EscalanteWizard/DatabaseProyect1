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
    public class SalariosController : ControllerBase
    {
        private readonly AppDbContext context;
        public SalariosController(AppDbContext context)
        {
            this.context = context;
        }        
        // GET api/<GruposController>/5
        [HttpGet]
        public ActionResult Get()
        {
            try
            {                
                SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection(); //nombre de la conexion
                SqlCommand comando = conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
                conexion.Open(); //apertura de la conexión
                comando.CommandType = System.Data.CommandType.Text;  //se define que el comando el del tipo procedimiento almacenado
                comando.CommandText = "ConsultrSalario";  //**((revisar la disponibilidad del método))
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
        public void Post([FromBody] Salarios salario )
        {
            try
            {
                if (ModelState.IsValid) {
                    SqlConnection conexion = (SqlConnection)context.Database.GetDbConnection(); //nombre de la conexion
                    SqlCommand comando = conexion.CreateCommand(); //comandos que se van a utilizar a travéz de la conexion
                    conexion.Open(); //apertura de la conexión
                    comando.CommandType = System.Data.CommandType.StoredProcedure;  //se define que el comando el del tipo procedimiento almacenado
                    comando.CommandText = "registro_salario";  //variable del texto del comando que se va a llamar a través de la conexión

                    comando.Parameters.Add("@monto", System.Data.SqlDbType.Int).Value = salario.monto;
                    comando.Parameters.Add("@inicio", System.Data.SqlDbType.Date).Value =salario.inicio;
                    comando.Parameters.Add("@final", System.Data.SqlDbType.Date).Value = salario.final.;
                    comando.Parameters.Add("@cedula_profesor", System.Data.SqlDbType.Int).Value = salario.cedula_profesor;
                    comando.Parameters.Add("@concepto", System.Data.SqlDbType.VarChar, 50).Value = salario.concepto;                    
                    comando.ExecuteNonQuery();
                    conexion.Close(); //cierre de la conexión
                    return Ok(salario);
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
        public void Put(DateTime id, [FromBody] Salario salario)
        {
             try
            {
                if (salario.inicio == id)
                {
                    context.Entry(salario).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetSalario", new { id = salario.inicio_periodo_salario }, salario);
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

        // DELETE api/<GruposController>/5
        [HttpDelete]
        public void Delete(int id)
        {
             try
            {
                var salario = context.Salario.FirstOrDefault(g => g.inicio_periodo_salario == id);
                if (salario != null)
                {
                    context.Salario.Remove(salario);
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
