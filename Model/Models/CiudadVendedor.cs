using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class CiudadVendedor
    {
        public byte CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string NUMERO_IDENTIFICACION { get; set; }
        public int CODIGO_CIUDAD { get; set; }
        public string DESCRIPCION { get; set; }
    }
    public class CiudadDescripcion
    {
        public byte CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
