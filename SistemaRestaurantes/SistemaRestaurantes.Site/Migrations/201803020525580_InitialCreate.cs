namespace SistemaRestaurantes.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pratoes",
                c => new
                    {
                        PratoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Restaurante_RestauranteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PratoId)
                .ForeignKey("dbo.Restaurantes", t => t.Restaurante_RestauranteId, cascadeDelete: true)
                .Index(t => t.Restaurante_RestauranteId);
            
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        RestauranteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RestauranteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pratoes", "Restaurante_RestauranteId", "dbo.Restaurantes");
            DropIndex("dbo.Pratoes", new[] { "Restaurante_RestauranteId" });
            DropTable("dbo.Restaurantes");
            DropTable("dbo.Pratoes");
        }
    }
}
