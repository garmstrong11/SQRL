namespace SQRL.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        LongUrlFormatString = c.String(maxLength: 512),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.UrlLinks",
                c => new
                    {
                        UrlLinkId = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 100),
                        LongUrl = c.String(maxLength: 512),
                        CategoryId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UrlLinkId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UrlLinks", new[] { "CategoryId" });
            DropForeignKey("dbo.UrlLinks", "CategoryId", "dbo.Categories");
            DropTable("dbo.UrlLinks");
            DropTable("dbo.Categories");
        }
    }
}
