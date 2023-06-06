using Microsoft.EntityFrameworkCore;
using StyleBackend.Models;
using StyleBackend.Models.Modelos;

namespace StyleBackend.Resources.ConectionSQL
{
    public class ConexionSQLServer : DbContext
    {
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options) : base(options)
        {
        }
        public DbSet<Batalla> Batalla { get; set; }
        public DbSet<SuperUsuario> SuperUsuario { get; set; }
        public DbSet<Torneo> Torneo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Votacion> Votacion { get; set; }
    }
}
