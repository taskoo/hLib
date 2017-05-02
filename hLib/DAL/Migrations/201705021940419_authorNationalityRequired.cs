namespace hLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorNationalityRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Author", "NationalityId", "dbo.Nationality");
            DropIndex("dbo.Author", new[] { "NationalityId" });
            AlterColumn("dbo.Author", "NationalityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Author", "NationalityId");
            AddForeignKey("dbo.Author", "NationalityId", "dbo.Nationality", "NationalityId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Author", "NationalityId", "dbo.Nationality");
            DropIndex("dbo.Author", new[] { "NationalityId" });
            AlterColumn("dbo.Author", "NationalityId", c => c.Int());
            CreateIndex("dbo.Author", "NationalityId");
            AddForeignKey("dbo.Author", "NationalityId", "dbo.Nationality", "NationalityId");
        }
    }
}
