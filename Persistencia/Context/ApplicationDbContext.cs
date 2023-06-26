using Microsoft.EntityFrameworkCore;
using Dominio.Administrador;
using Persistencia.FluentConfig.Administrador;


namespace Persistencia.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options){}

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UsuarioConfig(modelBuilder.Entity<Usuario>());
            new ModuloConfig(modelBuilder.Entity<Modulo>());
            new ActividadConfig(modelBuilder.Entity <Actividad>());
            new ConfiguracionConfig(modelBuilder.Entity<Configuracion>());
            new ActividadSeederConfig(modelBuilder.Entity <Actividad>());
            new RolSeederConfig(modelBuilder.Entity<Rol>());
            new ActividadRolSeederConfig(modelBuilder.Entity<ActividadRol>());
        }

        public DbSet<Actividad> Actividad { get; set; }
        public DbSet<Configuracion> Configuracion { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioRol> UsuarioRol { get; set; }
        public DbSet<ActividadRol> ActividadRol { get; set; }
        public DbSet<UsuarioCargo> UsuarioCargo { get; set; }
        public DbSet<UsuarioArea> UsuarioArea { get; set; }
        public DbSet<UsuarioPuntoAtencion> UsuarioPuntoAtencion { get; set; }
    }
}