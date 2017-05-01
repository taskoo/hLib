namespace hLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_state : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorFirstName = c.String(nullable: false, maxLength: 50),
                        AuthorMiddleName = c.String(maxLength: 50),
                        AuthorLastName = c.String(nullable: false, maxLength: 50),
                        NationalityId = c.Int(),
                    })
                .PrimaryKey(t => t.AuthorId)
                .ForeignKey("dbo.Nationality", t => t.NationalityId)
                .Index(t => t.NationalityId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        ISBN = c.String(maxLength: 17),
                        Description = c.String(maxLength: 500),
                        LanguageId = c.Int(nullable: false),
                        GenreId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Genre", t => t.GenreId)
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.ISBN, unique: true)
                .Index(t => t.LanguageId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.Nationality",
                c => new
                    {
                        NationalityId = c.Int(nullable: false, identity: true),
                        NationalityName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.NationalityId);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Author_Id })
                .ForeignKey("dbo.Book", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Author", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Author", "NationalityId", "dbo.Nationality");
            DropForeignKey("dbo.Book", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.Book", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Author");
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Book");
            DropIndex("dbo.BookAuthors", new[] { "Author_Id" });
            DropIndex("dbo.BookAuthors", new[] { "Book_Id" });
            DropIndex("dbo.Book", new[] { "GenreId" });
            DropIndex("dbo.Book", new[] { "LanguageId" });
            DropIndex("dbo.Book", new[] { "ISBN" });
            DropIndex("dbo.Author", new[] { "NationalityId" });
            DropTable("dbo.BookAuthors");
            DropTable("dbo.Nationality");
            DropTable("dbo.Language");
            DropTable("dbo.Genre");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
