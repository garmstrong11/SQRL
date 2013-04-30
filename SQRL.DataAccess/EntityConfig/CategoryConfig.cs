using System.Data.Entity.ModelConfiguration;
using SQRL.Domain;

namespace SQRL.DataAccess.EntityConfig
{
	public class CategoryConfig : EntityTypeConfiguration<Category>
	{
		public CategoryConfig()
		{
			//HasMany(c => c.UrlLinks).WithRequired(u => u.Category);
			Property(c => c.Name).IsRequired().HasMaxLength(100);
			Property(c => c.LongUrlFormatString).HasMaxLength(512);
		}
	}
}