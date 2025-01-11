using ProiectAmss.Models;

namespace ProiectAmss.Services
{
    public interface IEventsService
    {
        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event> GetByIdAsync(int id);
        Task AddAsync(Event @event, string userId);
        void Update(Event @event);
        void Delete(Event @event);
        Task<bool> ExistsAsync(int id);
        Task AddGameToEventAsync(int eventId, int gameId);
        Task ChooseGameForEventAsync(int eventId, int gameId);
    }
}
