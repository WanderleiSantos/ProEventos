using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<Evento> Eventos { get; set; }
    }
}