using DeviceDataApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceDataApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ParameterSensor> ParametroSensores { get; set; }
        public DbSet<ParameterDescription> ParametrosDescripcion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ParameterSensor>().ToTable("parametro_sensores");
            modelBuilder.Entity<ParameterDescription>().ToTable("parametros_descripcion");
            // Puedes agregar configuraciones adicionales si es necesario

            modelBuilder.Entity<ParameterSensor>().ToTable("parametro_sensores").Property(p => p.Id).HasColumnName("id");

            modelBuilder.Entity<ParameterSensor>().Property(p => p.CodigoParametro).HasColumnName("codigo_parametro");

            modelBuilder.Entity<ParameterSensor>().Property(p => p.ParametroSensoresId).HasColumnName("parametro_sensores_id");

            modelBuilder.Entity<ParameterSensor>().Property(p => p.NombreParametro).HasColumnName("nombre_parametro");

            modelBuilder.Entity<ParameterSensor>().Property(p => p.FechaDato).HasColumnName("fecha_dato");

            modelBuilder.Entity<ParameterSensor>().Property(p => p.ValorNumero).HasColumnName("valor_numero");

            modelBuilder.Entity<ParameterDescription>().ToTable("parametros_descripcion").Property(p => p.Id).HasColumnName("id");

            modelBuilder.Entity<ParameterDescription>().Property(p => p.CodigoParametro).HasColumnName("codigo_parametro");

            modelBuilder.Entity<ParameterDescription>().Property(p => p.DescripcionLarga).HasColumnName("descripcion_larga");

            modelBuilder.Entity<ParameterDescription>().Property(p => p.DescripcionMed).HasColumnName("descripcion_med");

            modelBuilder.Entity<ParameterDescription>().Property(p => p.DescripcionCorta).HasColumnName("descripcion_corta");

            modelBuilder.Entity<ParameterDescription>().Property(p => p.Abreviacion).HasColumnName("abreviacion");

            modelBuilder.Entity<ParameterDescription>().Property(p => p.Observacion).HasColumnName("observacion");

            modelBuilder.Entity<ParameterDescription>().Property(p => p.FechaCreacion).HasColumnName("fecha_creacion");

            modelBuilder.Entity<ParameterDescription>().Property(p => p.FechaModificacion).HasColumnName("fecha_modificacion");

            modelBuilder.Entity<ParameterDescription>().Property(p => p.Estado).HasColumnName("estado");

            modelBuilder.Entity<ParameterDescription>().Property(p => p.Unidad).HasColumnName("unidad");
        
        }
    }
}
