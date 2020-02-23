using System.Threading.Tasks;
using GolLabs.Domain;

namespace GolLabs.Repository
{
    public interface IGolLabsRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //RESERVA
        Task<Reserva[]> GetAllReservaAsync();
        Task<Reserva> GetAllReservaAsyncById(int ReservaId);
        
    }
}