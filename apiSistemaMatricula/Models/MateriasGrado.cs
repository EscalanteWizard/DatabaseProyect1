using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class MateriasGrado
    {
        [ForeignKey("Grados")]
        [Key]
        public int numero_grado { get; set; }

        [Key]
        [Column(TypeName = "varchar(50)")]
        public string nombre { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string descripcion_materia { get; set; }
        public int costo { get; set; }
    }
}
