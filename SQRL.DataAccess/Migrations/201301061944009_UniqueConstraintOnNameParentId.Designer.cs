// <auto-generated />
namespace SQRL.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    public sealed partial class UniqueConstraintOnNameParentId : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(UniqueConstraintOnNameParentId));
        
        string IMigrationMetadata.Id
        {
            get { return "201301061944009_UniqueConstraintOnNameParentId"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
