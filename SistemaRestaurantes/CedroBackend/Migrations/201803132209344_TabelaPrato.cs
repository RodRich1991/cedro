namespace CedroBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaPrato : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pratoes",
                c => new
                    {
                        PratoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        IdRestaurante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PratoId)
                .ForeignKey("dbo.Restaurantes", t => t.IdRestaurante, cascadeDelete: true)
                .Index(t => t.IdRestaurante);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pratoes", "IdRestaurante", "dbo.Restaurantes");
            DropIndex("dbo.Pratoes", new[] { "IdRestaurante" });
            DropTable("dbo.Pratoes");
        }
    }
}
