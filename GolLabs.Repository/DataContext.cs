using Microsoft.EntityFrameworkCore;
using GolLabs.Domain;

namespace GolLabs.Repository
{
    public class DataContext : DbContext{
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Reserva> Reservas { get; set; }
    }
}