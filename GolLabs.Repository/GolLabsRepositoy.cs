using System.Linq;
using System.Threading.Tasks;
using GolLabs.Domain;
using Microsoft.EntityFrameworkCore;

namespace GolLabs.Repository
{
    public class GolLabsRepository : IGolLabsRepository
    {
        private readonly DataContext _context;

         public GolLabsRepository(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Reserva[]> GetAllReservaAsync()
        {
            IQueryable<Reserva> query = _context.Reservas.AsNoTracking().OrderByDescending(r => r.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Reserva> GetAllReservaAsyncById(int ReservaId)
        {
            IQueryable<Reserva> query = _context.Reservas.AsNoTracking()
            .Where(r => r.Id == ReservaId).OrderByDescending(r => r.Id);
            return await query.FirstOrDefaultAsync();
        }
    }
}