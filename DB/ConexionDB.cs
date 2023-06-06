using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DB
{
    public class ConexionDB : DbContext
    {

    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        //public DbSet<Usuario> Users { get; set; }
    }



    }
}