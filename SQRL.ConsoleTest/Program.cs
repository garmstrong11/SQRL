using System;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using SQRL.DataAccess;
using SQRL.Domain;
using System.Linq;

namespace SQRL.ConsoleTest
{
	internal class Program
	{
		private static void Main()
		{
			//InsertCategory();
			//InsertLinkUrl();
			TestNameCategoryConstraint();
			Console.ReadLine();
		}

		private static void TestNameCategoryConstraint()
		{
			using (var ctx = new SqrlContext())
			{
				var lowes = ctx.Categories.FirstOrDefault(c => c.Name == "Lowes");
				var link = new UrlLink { Name = "LLLLL", Category = lowes };

				ctx.UrlLinks.Add(link);
				//ctx.SaveChanges();
				try
				{
					ctx.SaveChanges();
				}
				catch (DbUpdateException exc)
				{
					if (exc.InnerException.InnerException.Message.Contains("UQ_Name_ParentId"))
					{
						Console.WriteLine("Tag name is not unique for this category. Please try a different tag name.");
					}
				}
			}
		}

		private static void InsertLinkUrl()
		{
			using (var ctx = new SqrlContext())
			{
				var lowes = ctx.Categories.FirstOrDefault(c => c.Name == "Lowes");

				for (var i = 0; i < 10; i++)
				{
					var link = new UrlLink();
					link.Name = string.Format("L{0}", link.UrlLinkId);
					link.LongUrl = string.Format("http://mobile.plantfinder.com/?PlantId={0}&FromTag=true", link.Name);
					link.Category = lowes;

					while (ctx.UrlLinks.Any(u => u.UrlLinkId == link.UrlLinkId))
					{
						link.UrlLinkId = RandomGen.RandomString(SQRL.Domain.Properties.Settings.Default.RandomStringLength);
					}

					ctx.UrlLinks.Add(link);
					ctx.SaveChanges();
				}
				//ctx.SaveChanges();
			}
		}

		private static void InsertCategory()
		{
			//var lowes = new Category {
			//  Name = "Lowes"
			//};
			//var mon = new Category {
			//  Name = "Monrovia"
			//};


			using (var ctx = new SqrlContext())
			{
				//var root = ctx.Categories.FirstOrDefault(c => c.Name == "Root");
				var lowes = ctx.Categories.FirstOrDefault(c => c.Name == "Lowes");

				for (var i = 0; i < 1; i++)
				{
					var link = new UrlLink();
					link.Name = string.Format("L{0}", i.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
					link.UrlLinkId = "20pN4";
					link.LongUrl = string.Format("http://mobile.plantfinder.com/?PlantId={0}&FromTag=true", link.Name);
					link.Category = lowes;
					ctx.UrlLinks.Add(link);
					var valErrors = ctx.GetValidationErrors();
					if (!valErrors.Any())
					{
						ctx.SaveChanges();
					}
				}
				//ctx.Categories.Add(lowes);
				//ctx.Categories.Add(mon);
				//ctx.SaveChanges();
			}
		}
	}
}
