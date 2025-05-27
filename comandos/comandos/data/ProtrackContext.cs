using comandos.data.model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace comandos.data
{
    public class ProtrackContext : DbContext
    {
        public ProtrackContext() : base("name=ProtrackEntities")
        {
            Database.SetInitializer<ProtrackContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Disable pluralization
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AccesoUsuarioAplicacion> AccesoUsuarioAplicacion { get; set; }
        public DbSet<UsuarioAplicacion> UsuarioAplicacion { get; set; }
        public DbSet<Comando> Comando { get; set; }
        public DbSet<LogDatos> LogDatos { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
    }
}
