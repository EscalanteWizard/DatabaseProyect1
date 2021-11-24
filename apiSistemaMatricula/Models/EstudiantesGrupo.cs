using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class EstudiantesGrupo
    {
        [ForeignKey("Grupos")]
        [Key]
        public int codigo_grupo { get; set; }

        [ForeignKey("Grupos")]
        [Key]
        public int periodo { get; set; }

        [ForeignKey("Grupos")]
        [Key]
        public int anho_periodo { get; set; }

        [Key]
        [ForeignKey("Grupos")]
        [Column(TypeName = "VarChar(50)")]
        public string nombre_materia { get; set; }

        [ForeignKey("Grupos")]
        [Key]
        public int numero_grado { get; set; }

        [ForeignKey("Estudiantes")]
        [Key]
        public int cedula_estudiante { get; set; }
    }
}
