using System.Data.Entity;
using EasyHarmonica.DAL.Entities;
using EasyHarmonica.DAL.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyHarmonica.DAL.EF
{
    public class EasyHarmonicaContext:IdentityDbContext<User>
    {
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public EasyHarmonicaContext():base("EasyHarmonicaConnection")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EasyHarmonicaContext, Configuration>());
        }
    }
}
