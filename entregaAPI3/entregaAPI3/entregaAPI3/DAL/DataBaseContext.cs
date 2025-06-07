using _3er_entregable.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace _3er_entregable.DAL
{
    public class DataBaseContext : DbContext
    {
        // Asi me conecto a la BD por medio del constructor
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        // Este metodo que es propio de EF Core me sirve para configurar unos índices de cada campo de una tabla en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); // Crea un índice en el campo Name de la tabla Country
            modelBuilder.Entity<State>().HasIndex("Name","CountryId").IsUnique(); // indice compuesto
        }

        #region
        public DbSet<Country> Countries { get; set; } // Tabla de paises

        public DbSet<State> States { get; set; } // Tabla de estados/departamentos

        #endregion


    }
}
