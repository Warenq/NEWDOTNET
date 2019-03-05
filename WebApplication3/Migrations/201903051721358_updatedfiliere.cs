namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedfiliere : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Filiere_id", c => c.Int());
            CreateIndex("dbo.Users", "Filiere_id");
            AddForeignKey("dbo.Users", "Filiere_id", "dbo.Filieres", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Filiere_id", "dbo.Filieres");
            DropIndex("dbo.Users", new[] { "Filiere_id" });
            DropColumn("dbo.Users", "Filiere_id");
        }
    }
}
