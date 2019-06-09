namespace NITBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "imageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "imageUrl");
        }
    }
}
