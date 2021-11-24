using apiSistemaMatricula.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Context
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Estudiantes> Estudiante { get; set; }
    }
}
