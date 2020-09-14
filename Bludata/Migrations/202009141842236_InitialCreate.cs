namespace Bludata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        CNPJ = c.String(maxLength: 100),
                        UF = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        CNPJ = c.String(maxLength: 100),
                        DataHora = c.DateTime(nullable: false),
                        Telefone = c.String(maxLength: 100),
                        EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fornecedor", "EmpresaId", "dbo.Empresa");
            DropIndex("dbo.Fornecedor", new[] { "EmpresaId" });
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Empresa");
        }
    }
}
