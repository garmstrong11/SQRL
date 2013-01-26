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
			const string nameL = "L5450";
			const string nameM = "MLN20527";

			var lowes = new Category {
				Name = "Lowes",
				LongUrlFormatString = "http://plantguide.lowes.com/mobile/plant.aspx?code={0}&fromTag=true"
			};

			var mapleleaf = new Category {
				Name = "Mapleleaf",
				LongUrlFormatString = "http://mapleleaf.hortmp.com/mobile/plant.aspx?code={0}"
			};

			context.Categories.AddOrUpdate(
				p => p.Name, new[] { lowes, mapleleaf }
			);

			context.SaveChanges();

			context.UrlLinks.AddOrUpdate(
				p => new { p.Name, p.CategoryId },
				new UrlLink
				{
					Name = nameL,
					LongUrl = string.Format(lowes.LongUrlFormatString, nameL),
					CategoryId = lowes.CategoryId
				},
				new UrlLink
				{
					Name = nameM,
					LongUrl = string.Format(mapleleaf.LongUrlFormatString, nameM),
					CategoryId = mapleleaf.CategoryId
				}
			);

			context.SaveChanges();
		}
	}
}
