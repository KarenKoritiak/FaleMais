namespace FaleMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        EstadoUF = c.String(nullable: false, maxLength: 128),
                        DDDNumero = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DDDs", t => t.DDDNumero)
                .ForeignKey("dbo.Estados", t => t.EstadoUF)
                .Index(t => t.DDDNumero)
                .Index(t => t.EstadoUF);
            
            CreateTable(
                "dbo.DDDs",
                c => new
                    {
                        Numero = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Numero);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        UF = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UF);
            
            CreateTable(
                "dbo.FaleMaisPlanos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Minutos = c.Int(nullable: false),
                        AcrescimoMinutosExcedentes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tarifas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrigemNumero = c.String(nullable: false, maxLength: 128),
                        DestinoNumero = c.String(nullable: false, maxLength: 128),
                        ValorPorMinuto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DDDs", t => t.DestinoNumero)
                .ForeignKey("dbo.DDDs", t => t.OrigemNumero)
                .Index(t => t.DestinoNumero)
                .Index(t => t.OrigemNumero);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarifas", "OrigemNumero", "dbo.DDDs");
            DropForeignKey("dbo.Tarifas", "DestinoNumero", "dbo.DDDs");
            DropForeignKey("dbo.Cidades", "EstadoUF", "dbo.Estados");
            DropForeignKey("dbo.Cidades", "DDDNumero", "dbo.DDDs");
            DropIndex("dbo.Tarifas", new[] { "OrigemNumero" });
            DropIndex("dbo.Tarifas", new[] { "DestinoNumero" });
            DropIndex("dbo.Cidades", new[] { "EstadoUF" });
            DropIndex("dbo.Cidades", new[] { "DDDNumero" });
            DropTable("dbo.Tarifas");
            DropTable("dbo.FaleMaisPlanos");
            DropTable("dbo.Estados");
            DropTable("dbo.DDDs");
            DropTable("dbo.Cidades");
        }
    }
}
