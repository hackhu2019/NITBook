namespace NITBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BookSorts");
            AlterColumn("dbo.BookSorts", "SortId", c => c.Int(nullable: false, identity: false));
            AddPrimaryKey("dbo.BookSorts", "SortId");
        }

        public override void Down()
        {
            DropTable("dbo.BookSorts");
        }
    }
}
