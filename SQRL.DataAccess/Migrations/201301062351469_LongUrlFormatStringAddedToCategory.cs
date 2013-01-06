using System.Data.Entity.Migrations;

namespace SQRL.DataAccess.Migrations
{
	public partial class LongUrlFormatStringAddedToCategory : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.Categories", "LongUrlFormatString", c => c.String(maxLength: 512));
		}

		public override void Down()
		{
			DropColumn("dbo.Categories", "LongUrlFormatString");
		}
	}
}