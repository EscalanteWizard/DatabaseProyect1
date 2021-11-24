using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class Padres
    {
        [Key]
        public int cedula { get; set; }

        public int telefono_conyugue { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string nombre_conyugue { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string profesion { get; set; }
    }
}

