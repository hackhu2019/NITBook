namespace NITBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        bookID = c.Int(nullable: false, identity: true),
                        bookName = c.String(),
                        ISBN = c.String(),
                        publicTime = c.DateTime(nullable: false),
                        author = c.String(),
                        sortID = c.String(),
                        number = c.Int(nullable: false),
                        info = c.String(),
                    })
                .PrimaryKey(t => t.bookID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
