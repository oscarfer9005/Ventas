using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Vendedor
    {
        [Key]
        public byte CODIGO { get; set; }
        [Required]
        public string NOMBRE { get; set; }
        [Required]
        public string APELLIDO { get; set; }
        [Required]
        public string NUMERO_IDENTIFICACION { get; set; }
        [Required]
        public int CODIGO_CIUDAD { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}
