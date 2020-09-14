namespace Bludata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anre : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empresa", "Nome", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Empresa", "CNPJ", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Empresa", "UF", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Fornecedor", "Nome", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Fornecedor", "CNPJ", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Fornecedor", "Telefone", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fornecedor", "Telefone", c => c.String(maxLength: 100));
            AlterColumn("dbo.Fornecedor", "CNPJ", c => c.String(maxLength: 100));
            AlterColumn("dbo.Fornecedor", "Nome", c => c.String(maxLength: 100));
            AlterColumn("dbo.Empresa", "UF", c => c.String(maxLength: 100));
            AlterColumn("dbo.Empresa", "CNPJ", c => c.String(maxLength: 100));
            AlterColumn("dbo.Empresa", "Nome", c => c.String(maxLength: 100));
        }
    }
}
