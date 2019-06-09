namespace NITBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "sort", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "bookName", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "author", c => c.String(nullable: false));
            DropColumn("dbo.Books", "sortID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "sortID", c => c.String());
            AlterColumn("dbo.Books", "author", c => c.String());
            AlterColumn("dbo.Books", "ISBN", c => c.String());
            AlterColumn("dbo.Books", "bookName", c => c.String());
            DropColumn("dbo.Books", "sort");
        }
    }
}
