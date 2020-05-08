namespace VendedoresApp.Migrations
{
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VendedoresApp.Models.VendedoresAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VendedoresApp.Models.VendedoresAppContext context)
        {
            var ciudad = new List<Ciudad>
            {
                new Ciudad(){CODIGO=1,DESCRIPCION="Bogota"},
                new Ciudad(){CODIGO=2,DESCRIPCION="Cali"}
            };

            ciudad.ForEach(c => context.Ciudads.Add(c));
            context.SaveChanges();

            var vendedor = new List<Vendedor>
            {
                new Vendedor(){CODIGO=10,NOMBRE="JUAN",APELLIDO="POLANCO",NUMERO_IDENTIFICACION="1111111111",CODIGO_CIUDAD=1},
                new Vendedor(){CODIGO=20,NOMBRE="PEDRO",APELLIDO="REYES",NUMERO_IDENTIFICACION="2222222222",CODIGO_CIUDAD=2},
                new Vendedor(){CODIGO=30,NOMBRE="MARIA",APELLIDO="PAZ",NUMERO_IDENTIFICACION="3333333333",CODIGO_CIUDAD=1},
                new Vendedor(){CODIGO=40,NOMBRE="LUNA",APELLIDO="MONROY",NUMERO_IDENTIFICACION="4444444444",CODIGO_CIUDAD=1}
            };

            vendedor.ForEach(v => context.Vendedors.Add(v));
            context.SaveChanges();
        }
    }
}
