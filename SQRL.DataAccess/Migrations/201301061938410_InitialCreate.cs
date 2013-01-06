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
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UrlLinks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 100),
                        LongUrl = c.String(maxLength: 512),
                        Created = c.DateTime(nullable: false),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UrlLinks", new[] { "Parent_Id" });
            DropForeignKey("dbo.UrlLinks", "Parent_Id", "dbo.Categories");
            DropTable("dbo.UrlLinks");
            DropTable("dbo.Categories");
        }
    }
}
