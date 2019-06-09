namespace NITBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookPublicName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "publicName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "publicName");
        }
    }
}
