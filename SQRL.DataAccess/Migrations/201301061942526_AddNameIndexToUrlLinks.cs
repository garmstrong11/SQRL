using System.Data.Entity.Migrations;

namespace SQRL.DataAccess.Migrations
{
	public partial class AddNameIndexToUrlLinks : DbMigration
	{
		public override void Up()
		{
			CreateIndex("UrlLinks", "Name", false, "IX_Name");
		}

		public override void Down()
		{
			DropIndex("UrlLinks", "IX_Name");
		}
	}
}