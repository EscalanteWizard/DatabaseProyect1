using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class EvaluacionesGrupoEstudiante
    {
        [ForeignKey("EvaluacionesGrupo")]
        [Key]
        public int grupo { get; set; }

        [ForeignKey("EvaluacionesGrupo")]
        [Key]
        public int numero_periodo { get; set; }

        [ForeignKey("EvaluacionesGrupo")]
        [Key]
        public int anho_periodo { get; set; }

        [Key]
        [ForeignKey("EvaluacionesGrupo")]
        [Column(TypeName = "VarChar(50)")]
        public string nombre_materia { get; set; }

        [ForeignKey("EvaluacionesGrupo")]
        [Key]
        public int grado { get; set; }

        [ForeignKey("Estudiantes")]
        [Key]
        public int cedula_estudiante { get; set; }

        [Key]
        [Column(TypeName = "VarChar(50)")]
        public string criterio { get; set; }

        public int nota { get; set; }
    }
}
