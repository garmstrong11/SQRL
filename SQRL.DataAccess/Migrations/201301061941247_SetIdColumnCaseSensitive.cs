using System.Data.Entity.Migrations;
using System.Text;

namespace SQRL.DataAccess.Migrations
{
	public partial class SetIdColumnCaseSensitive : DbMigration
	{
		public override void Up()
		{
			var sb = new StringBuilder();
			sb.AppendLine("ALTER TABLE [dbo].[UrlLinks] DROP CONSTRAINT [PK_dbo.UrlLinks]");
			sb.AppendLine("ALTER TABLE [dbo].[UrlLinks] ALTER COLUMN Id VARCHAR(5) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL");

			sb.AppendLine("ALTER TABLE [dbo].[UrlLinks] ADD CONSTRAINT [PK_dbo.UrlLinks] PRIMARY KEY CLUSTERED ([Id] ASC)");
			sb.Append("WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ");
			sb.AppendLine("IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

			Sql(sb.ToString());
		}

		public override void Down()
		{
			var sb = new StringBuilder();
			sb.AppendLine("ALTER TABLE [dbo].[UrlLinks] DROP CONSTRAINT [PK_dbo.UrlLinks]");
			sb.AppendLine("ALTER TABLE [dbo].[UrlLinks] ALTER COLUMN Id VARCHAR(5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL");

			sb.AppendLine("ALTER TABLE [dbo].[UrlLinks] ADD CONSTRAINT [PK_dbo.UrlLinks] PRIMARY KEY CLUSTERED ([Id] ASC)");
			sb.Append("WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ");
			sb.AppendLine("IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

			Sql(sb.ToString());
		}
	}
}