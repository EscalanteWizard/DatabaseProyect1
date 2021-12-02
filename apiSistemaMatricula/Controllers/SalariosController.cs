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
        public void Post([FromBody] )
        {
        }

        // PUT api/<GruposController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GruposController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
