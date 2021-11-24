using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class Asistencias
    {
        [ForeignKey("EstudiantesGrupo")]
        [Key]
        public int grupo { get; set; }

        [ForeignKey("EstudiantesGrupo")]
        [Key]
        public int numero_periodo { get; set; }

        [ForeignKey("EstudiantesGrupo")]
        [Key]
        public int anho_periodo { get; set; }

        [Key]
        [ForeignKey("EstudiantesGrupo")]
        [Column(TypeName = "VarChar(50)")]
        public string nombre_materia { get; set; }

        [ForeignKey("EstudiantesGrupo")]
        [Key]
        public int grado { get; set; }

        [ForeignKey("EstudiantesGrupo")]
        [Key]
        public int cedula_estudiante { get; set; }

        [Key]
        [Column(TypeName = "Date")]
        public DateTime fechal { get; set; }

    }
}

