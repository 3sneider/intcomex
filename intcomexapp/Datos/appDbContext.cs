using intcomexapp.Models;
using Microsoft.EntityFrameworkCore;

namespace intcomexapp.Datos
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options): base(options)
        {
            
        }

        public DbSet<Contacto> contactos { get; set; }
    }
}