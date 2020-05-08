namespace VendedoresApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ciudads",
                c => new
                    {
                        CODIGO = c.Byte(nullable: false),
                        DESCRIPCION = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CODIGO);
            
            CreateTable(
                "dbo.Vendedors",
                c => new
                    {
                        CODIGO = c.Byte(nullable: false),
                        NOMBRE = c.String(nullable: false),
                        APELLIDO = c.String(nullable: false),
                        NUMERO_IDENTIFICACION = c.String(nullable: false),
                        CODIGO_CIUDAD = c.Int(nullable: false),
                        Ciudad_CODIGO = c.Byte(),
                    })
                .PrimaryKey(t => t.CODIGO)
                .ForeignKey("dbo.Ciudads", t => t.Ciudad_CODIGO)
                .Index(t => t.Ciudad_CODIGO);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendedors", "Ciudad_CODIGO", "dbo.Ciudads");
            DropIndex("dbo.Vendedors", new[] { "Ciudad_CODIGO" });
            DropTable("dbo.Vendedors");
            DropTable("dbo.Ciudads");
        }
    }
}
