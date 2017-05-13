namespace SGMI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CidadeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EstadoModels", t => t.EstadoId, cascadeDelete: true)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.EstadoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sigla = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MembrosModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Telefone = c.String(maxLength: 15),
                        Email = c.String(maxLength: 100),
                        Cpf = c.String(nullable: false, maxLength: 14),
                        Endereco = c.String(nullable: false, maxLength: 200),
                        CidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CidadeModels", t => t.CidadeId, cascadeDelete: true)
                .Index(t => t.CidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MembrosModel", "CidadeId", "dbo.CidadeModels");
            DropForeignKey("dbo.CidadeModels", "EstadoId", "dbo.EstadoModels");
            DropIndex("dbo.MembrosModel", new[] { "CidadeId" });
            DropIndex("dbo.CidadeModels", new[] { "EstadoId" });
            DropTable("dbo.MembrosModel");
            DropTable("dbo.EstadoModels");
            DropTable("dbo.CidadeModels");
        }
    }
}
