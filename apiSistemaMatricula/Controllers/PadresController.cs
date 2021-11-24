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
    public class PadresController : ControllerBase
    {
        private readonly AppDbContext context;
        public PadresController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<GruposController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GruposController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GruposController>
        [HttpPost]
        public void Post([FromBody] string value)
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
