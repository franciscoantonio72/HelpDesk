namespace HelpDesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HelpDeskContext1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Os",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Cliente_Id = c.Int(nullable: false),
                        Tecnico_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tecnicoes", t => t.Tecnico_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Tecnico_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Os", new[] { "Tecnico_Id" });
            DropIndex("dbo.Os", new[] { "Cliente_Id" });
            DropForeignKey("dbo.Os", "Tecnico_Id", "dbo.Tecnicoes");
            DropForeignKey("dbo.Os", "Cliente_Id", "dbo.Clientes");
            DropTable("dbo.Os");
        }
    }
}
