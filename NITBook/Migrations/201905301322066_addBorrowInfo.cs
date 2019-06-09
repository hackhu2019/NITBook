namespace NITBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBorrowInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BorrowInfoes",
                c => new
                    {
                        borrow_Id = c.Int(nullable: false, identity: true),
                        bookName = c.String(nullable: false),
                        readerId = c.Int(nullable: false),
                        borrowTime = c.DateTime(nullable: false),
                        backTime = c.DateTime(),
                        isBeyond = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.borrow_Id);
            
            AddColumn("dbo.Books", "borrowNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "borrowNumber");
            DropTable("dbo.BorrowInfoes");
        }
    }
}
