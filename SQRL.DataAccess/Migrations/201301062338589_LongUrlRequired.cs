namespace SQRL.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LongUrlRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UrlLinks", "LongUrl", c => c.String(nullable: false, maxLength: 512));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UrlLinks", "LongUrl", c => c.String(maxLength: 512));
        }
    }
}
