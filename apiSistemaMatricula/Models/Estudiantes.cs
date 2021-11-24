using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class Estudiantes
    {
        [Key]
        public int cedula { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public int cedula_padre { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public int numero_grado { get; set; }
    }
}
