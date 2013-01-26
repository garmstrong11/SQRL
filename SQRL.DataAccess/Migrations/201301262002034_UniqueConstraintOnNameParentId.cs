using System.Data.Entity.Migrations;
using System.Text;

namespace SQRL.DataAccess.Migrations
{
	public partial class UniqueConstraintOnNameParentId : DbMigration
	{
		public override void Up()
		{
			var sb = new StringBuilder();

			sb.AppendLine("ALTER TABLE UrlLinks ADD CONSTRAINT UQ_Name_CategoryId UNIQUE([Name], [CategoryId])");
			sb.Append("WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ");
			sb.AppendLine("IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

			Sql(sb.ToString());
		}

		public override void Down()
		{
			var sb = new StringBuilder();

			sb.AppendLine("ALTER TABLE [dbo].[UrlLinks] DROP CONSTRAINT UQ_Name_CategoryId");

			Sql(sb.ToString());
		}
	}
}