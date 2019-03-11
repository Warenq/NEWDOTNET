namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cours",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Etudiants",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        prenom = c.String(),
                        Filiere_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Filieres", t => t.Filiere_id)
                .Index(t => t.Filiere_id);
            
            CreateTable(
                "dbo.Filieres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        libelle = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Etudiants", "Filiere_id", "dbo.Filieres");
            DropIndex("dbo.Etudiants", new[] { "Filiere_id" });
            DropTable("dbo.Filieres");
            DropTable("dbo.Etudiants");
            DropTable("dbo.Cours");
        }
    }
}
