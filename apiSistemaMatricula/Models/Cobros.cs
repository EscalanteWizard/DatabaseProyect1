using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class Cobros
    {
        [ForeignKey("Matriculas")]
        [Key]
        [Column(TypeName = "VarChar(50)")]
        public string codigo_grupo { get; set; }

        [ForeignKey("Matriculas")]
        [Key]
        public int numero_periodo { get; set; }

        [ForeignKey("Matriculas")]
        [Key]
        public int anho_periodo { get; set; }

        [Key]
        [ForeignKey("Matriculas")]
        [Column(TypeName = "VarChar(50)")]
        public string nombre_materia { get; set; }

        [ForeignKey("Matriculas")]
        [Key]
        public int numero_grado { get; set; }

        [Key]
        [ForeignKey("Matriculas")]
        public int estudiante { get; set; }

        [Column(TypeName = "Date")]
        public DateTime fecha_generacion { get; set; }

        [Column(TypeName = "Date")]
        public DateTime fecha_pago { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string concepto { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string estado { get; set; }

        public int monto { get; set; }
    }
}
