using System.Data.Entity.ModelConfiguration;
using SQRL.Domain;

namespace SQRL.DataAccess.EntityConfig
{
	public class CategoryConfig : EntityTypeConfiguration<Category>
	{
		public CategoryConfig()
		{
			HasMany(p => p.UrlLinks);
			Property(p => p.Name).IsRequired().HasMaxLength(100);
			Property(p => p.LongUrlFormatString).HasMaxLength(512);
		}
	}
}