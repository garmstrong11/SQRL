using System.Data.Entity;
using SQRL.DataAccess.EntityConfig;
using SQRL.Domain;

namespace SQRL.DataAccess
{
	public class SqrlContext : DbContext
	{
		public DbSet<Category> Categories { get; set; }
		public DbSet<UrlLink> UrlLinks { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new CategoryConfig());
			modelBuilder.Configurations.Add(new UrlLinkConfig());
		}
	}
}