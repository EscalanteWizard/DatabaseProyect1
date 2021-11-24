using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class Periodos
    {
        [ForeignKey("Periodos")]
        [Key]
        public int numero { get; set; }

        [ForeignKey("Periodos")]
        [Key]
        public int anho { get; set; }

        [Column(TypeName = "Date")]
        public DateTime fecha_inicio { get; set; }

        [Column(TypeName = "Date")]
        public DateTime fecha_final { get; set; }


        public int nota_minma { get; set; }
        public int estado { get; set; }
    }
}
