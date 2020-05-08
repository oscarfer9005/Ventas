using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Functions
{
    public class CiudadFunctions
    {
        private CiudadVentaContext db = new CiudadVentaContext();

        public CiudadDescripcion GetCiudadByCodigo(string descripcion)
        {
            var data = from c in db.Ciudads
                       where c.DESCRIPCION == descripcion
                       select new CiudadDescripcion
                       {
                           CODIGO = c.CODIGO,
                           DESCRIPCION = c.DESCRIPCION
                       };
            return data.FirstOrDefault();
        }

        public byte GetLastCiudadCode()
        {
            var data = from c in db.Ciudads
                       orderby c.CODIGO descending
                       select new CiudadDescripcion
                       {
                           CODIGO = c.CODIGO
                       };
            return data.FirstOrDefault().CODIGO;
        }

        public void CreateCiudad(Ciudad ciudad)
        {
            if (ciudad == null)
            {
                throw new NotImplementedException("Ciudad no se ha inicializado");
            }
            else
            {
                var ciud = GetCiudadByCodigo(ciudad.DESCRIPCION);
                byte codigo = 0;
                if (ciud == null)
                {
                    codigo = GetLastCiudadCode();
                    ciudad.CODIGO = ++codigo;
                    db.Ciudads.Add(ciudad);
                    db.SaveChanges();
                }
            }
        }
    }
}