using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiSistemaMatricula.Models
{
    public class Salarios
    {
        [Key]
        public int profesor { get; set; }
        
        [Key]
        [Column(TypeName = "Date")]
        public DateTime inicio_periodo_salario { get; set; }
        
        [Key]
        [Column(TypeName = "Date")]
        public DateTime final_periodo_salario { get; set; }
        
        public int monto_salario { get; set; }

        [Column(TypeName = "VarChar(50)")]
        public string concepto{ get; set; }
    }
}
