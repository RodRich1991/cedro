namespace SistemaRestaurantes.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChaveEstrangeiraRestaurante : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pratoes", name: "Restaurante_RestauranteId", newName: "IdRestaurante");
            RenameIndex(table: "dbo.Pratoes", name: "IX_Restaurante_RestauranteId", newName: "IX_IdRestaurante");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Pratoes", name: "IX_IdRestaurante", newName: "IX_Restaurante_RestauranteId");
            RenameColumn(table: "dbo.Pratoes", name: "IdRestaurante", newName: "Restaurante_RestauranteId");
        }
    }
}
