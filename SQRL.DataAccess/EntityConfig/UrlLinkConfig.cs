using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SQRL.Domain;

namespace SQRL.DataAccess.EntityConfig
{
	public class UrlLinkConfig : EntityTypeConfiguration<UrlLink>
	{
		public UrlLinkConfig()
		{
			HasKey(p => p.Id);
			Property(p => p.Id).HasMaxLength(Domain.Properties.Settings.Default.RandomStringLength);
			Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			Property(p => p.LongUrl).HasMaxLength(512);
			Property(p => p.Name).IsRequired().HasMaxLength(100);
		}
	}
}