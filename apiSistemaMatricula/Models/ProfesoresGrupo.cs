using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class ProfesoresGrupo
    {
        [ForeignKey("Grupos")]
        [Key]
        public int grupo { get; set; }

        [ForeignKey("Grupos")]
        [Key]
        public int numero_periodo { get; set; }

        [ForeignKey("Grupos")]
        [Key]
        public int anho_periodo { get; set; }

        [Key]
        [ForeignKey("Grupos")]
        [Column(TypeName = "VarChar(50)")]
        public string nombre_materia { get; set; }

        [ForeignKey("Grupos")]
        [Key]
        public int grado { get; set; }

        [ForeignKey("Profesores")]
        [Key]
        public int profesor { get; set; }
    }
}
