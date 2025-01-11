using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProiectAmss.Models;
using ProiectAmss.Repositories;

namespace ProiectAmss.Services
{
    public class EventService : IEventsService
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly IPlayersService _playersService;
        private readonly IGamesRepository _gamesRepository;

        public EventService(IEventsRepository eventRepository, IPlayersService playersService, IGamesRepository gamesRepository)
        {
            _eventsRepository = eventRepository;
            _playersService = playersService;
            _gamesRepository = gamesRepository;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _eventsRepository.GetAllAsync();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _eventsRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Event @event, string userId)
        {
            Game game = await _gamesRepository.GetByIdAsync(@event.GameId);
            @event.Games = new List<Game>() { game };
            @event.OwnerId = userId;

            await _eventsRepository.AddAsync(@event);
            await _playersService.RegisterPlayerForEventAsync(userId, @event.Id);
        }

        public void Update(Event @event)
        {
            _eventsRepository.Update(@event);
            _eventsRepository.SaveChanges();
        }

        public void Delete(Event @event)
        {
            _eventsRepository.Delete(@event);
        }

        public Task<bool> ExistsAsync(int id)
        {
           return _eventsRepository.ExistsAsync(id);
        }

        public async Task AddGameToEventAsync(int eventId, int gameId)
        {
            Event @event = await _eventsRepository.GetByIdAsync(eventId);
            Game game = await _gamesRepository.GetByIdAsync(gameId);
            @event.Games.Add(game);
            _eventsRepository.SaveChanges();
        }

        public async Task ChooseGameForEventAsync(int eventId, int gameId)
        {
            Event @event = await _eventsRepository.GetByIdAsync(eventId);
            @event.ChosenGameId = gameId;
            _eventsRepository.SaveChanges();
        }
    }
}
