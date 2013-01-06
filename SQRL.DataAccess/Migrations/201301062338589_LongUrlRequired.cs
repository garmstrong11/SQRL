using System.Data.Entity.Migrations;

namespace SQRL.DataAccess.Migrations
{
	public partial class LongUrlRequired : DbMigration
	{
		public override void Up()
		{
			AlterColumn("dbo.UrlLinks", "LongUrl", c => c.String(false, 512));
		}

		public override void Down()
		{
			AlterColumn("dbo.UrlLinks", "LongUrl", c => c.String(maxLength: 512));
		}
	}
}