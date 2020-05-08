using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendedoresApp.Models;

namespace VendedoresApp.Functions
{
    public class VendedorFunctions

    {
        private VendedoresAppContext db = new VendedoresAppContext();

        public IQueryable<CiudadVendedor> GetALLVendedors()
        {
            var data = from v in db.Vendedors
                       join c in db.Ciudads on v.CODIGO_CIUDAD equals c.CODIGO
                       select new CiudadVendedor
                       {
                           CODIGO = v.CODIGO,
                           NOMBRE = v.NOMBRE,
                           APELLIDO = v.APELLIDO,
                           NUMERO_IDENTIFICACION = v.NUMERO_IDENTIFICACION,
                           CODIGO_CIUDAD = v.CODIGO_CIUDAD,
                           DESCRIPCION = c.DESCRIPCION
                       };
            return data;
        }

        public CiudadVendedor GetVendedorByCodigo(byte codigo)
        {
            var data = from v in db.Vendedors
                       join c in db.Ciudads on v.CODIGO_CIUDAD equals c.CODIGO
                       where v.CODIGO == codigo
                       select new CiudadVendedor
                       {
                           CODIGO = v.CODIGO,
                           NOMBRE = v.NOMBRE,
                           APELLIDO = v.APELLIDO,
                           NUMERO_IDENTIFICACION = v.NUMERO_IDENTIFICACION,
                           CODIGO_CIUDAD = v.CODIGO_CIUDAD,
                           DESCRIPCION = c.DESCRIPCION
                       };
            return data.FirstOrDefault();
        }

        public void CreateVendedor(Vendedor vendedor)
        {
            if (vendedor == null)
            {
                throw new NotImplementedException("Vendedor no se ha inicializado");
            }
            else
            {
                db.Vendedors.Add(vendedor);
                db.SaveChanges();
            }
        }

        internal bool EditVendedor(Vendedor vendedor)
        {
            db.Entry(vendedor).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        internal void DeleteVendedor(byte codigo)
        {
            var vendedorById = db.Vendedors.Where(v => v.CODIGO == codigo).ToList();
            if (vendedorById.Count > 0)
            {
                for (int i = 0; i < vendedorById.Count; i++)
                {
                    db.Vendedors.Remove(vendedorById[i]);
                }
                db.SaveChanges();

                var vendedorEntity = db.Vendedors.Where(v => v.CODIGO == codigo).SingleOrDefault();
                db.Vendedors.Remove(vendedorEntity);
                db.SaveChanges();
            }
        }
    }
}