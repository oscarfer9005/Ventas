using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Ciudad
    {
        [Key]
        public byte CODIGO { get; set; }
        [Required]
        public string DESCRIPCION { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; }
    }
}
