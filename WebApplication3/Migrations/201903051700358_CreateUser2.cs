namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUser2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "prenom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "prenom");
        }
    }
}
