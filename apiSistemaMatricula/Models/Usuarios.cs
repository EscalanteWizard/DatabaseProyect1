using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class Usuarios
    {
        [Key]
        public int cedula { get; set; }

        public int telefono { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string nombre { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string apellido1 { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string apellido2 { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string canton { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string ciudad { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string sexo { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string passw { get; set; }

        [Column(TypeName = "Date")]
        public DateTime fecha_nacimiento { get; set; }

        [Column(TypeName = "Date")]
        public DateTime fecha_creacion { get; set;}
    }
}
