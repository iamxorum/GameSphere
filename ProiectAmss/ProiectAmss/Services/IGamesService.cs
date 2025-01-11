using ProiectAmss.Models;

namespace ProiectAmss.Services
{
    public interface IGamesService
    {
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game> GetByIdAsync(int id);
        Task AddAsync(Game game);
        void Update(Game game);
        void Delete(Game game);
        Task<bool> ExistsAsync(int id);
    }
}
