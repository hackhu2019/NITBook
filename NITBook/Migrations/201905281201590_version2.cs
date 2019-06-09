namespace NITBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookSorts",
                c => new
                    {
                        SortId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.SortId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookSorts");
        }
    }
}
