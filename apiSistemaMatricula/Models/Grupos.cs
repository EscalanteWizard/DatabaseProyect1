using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class Grupos
    {
        [ForeignKey("Periodos")]
        [Key]
        [Column(TypeName = "VarChar(50)")]
        public string codigo { get; set; }

        [ForeignKey("Periodos")]
        [Key]
        public int numero_periodo { get; set; }

        [ForeignKey("Periodos")]
        [Key]
        public int anho_periodo { get; set; }

        [Key]
        [ForeignKey("Materias")]
        [Column(TypeName = "VarChar(50)")]
        public string nombre_materia { get; set; }

        [ForeignKey("Materias")]
        [Key]
        public int numero_grado { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string estado { get; set; }
        public int cupo { get; set; }
    }
}
