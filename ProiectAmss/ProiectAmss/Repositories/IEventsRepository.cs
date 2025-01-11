using ProiectAmss.Models;

namespace ProiectAmss.Repositories
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event> GetByIdAsync(int id);
        Task AddAsync(Event entity);
        void Update(Event entity);
        void Delete(Event entity);
        Task<bool> ExistsAsync(int id);
        void SaveChanges();
    }
}
