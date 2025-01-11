using ProiectAmss.Models;

namespace ProiectAmss.Repositories
{
    public interface IPlayerEventRepository
    {
        Task<IEnumerable<PlayerEvent>> GetAllAsync();
        Task<PlayerEvent> GetByIdAsync(int id);
        Task<PlayerEvent> GetByPlayerIdAndEventIdAsync(string playerId, int eventId);
        Task AddAsync(PlayerEvent playerEvent);
        void SaveChanges();
    }
}
