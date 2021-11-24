using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class Grados
    {
        [Key]
        public int numero { get; set; }

        [Column(TypeName = "varchar(50)")]
        public String descripcion { get; set; }
    }
}
