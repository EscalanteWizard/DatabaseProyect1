using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class Matriculas
    {
        [ForeignKey("Grupos")]
        [Key]
        public int codigo_grupo { get; set; }

        [ForeignKey("Grupos")]
        [Key]
        public int numero_periodo { get; set; }

        [ForeignKey("Grupos")]
        [Key]
        public int anho_periodo { get; set; }

        [Key]
        [ForeignKey("Grupos")]
        [Column(TypeName = "VarChar(50)")]
        public string materia { get; set; }

        [ForeignKey("Grupos")]
        [Key]
        public int grado { get; set; }

        [ForeignKey("Estudiantes")]
        [Key]
        public int estudiante { get; set; }

        [Key]
        [Column(TypeName = "VarChar(50)")]
        public string estado { get; set; }
    }
}
