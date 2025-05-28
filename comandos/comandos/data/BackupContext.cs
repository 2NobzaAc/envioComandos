using comandos.data.model;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace comandos.data
{
    public class BackupContext : DbContext
    {
        public BackupContext() : base("name=Backup")
        {
            Database.SetInitializer<ProtrackContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Disable pluralization
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<LogDatos> LogDatos { get; set; }
    }
}
