using System.Data.Entity.Migrations;
using SQRL.Domain;

namespace SQRL.DataAccess.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<SqrlContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(SqrlContext context)
		{
			var lowes = new Category { Name = "Lowes" };
			var monrovia = new Category { Name = "Monrovia" };

			context.Categories.AddOrUpdate(
				p => p.Name, new[] { lowes, monrovia }
			);

			context.UrlLinks.AddOrUpdate(
				p => new { p.Name, p.CategoryId },
				new UrlLink { Name = "LLLLL", LongUrl = "http://www.lowes.com", CategoryId = lowes.CategoryId },
				new UrlLink { Name = "MMMMM", LongUrl = "http://www.monrovia.com", CategoryId = monrovia.CategoryId }
			);
		}
	}
}
