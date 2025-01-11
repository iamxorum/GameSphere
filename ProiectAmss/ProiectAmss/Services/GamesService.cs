using ProiectAmss.Models;
using ProiectAmss.Repositories;

namespace ProiectAmss.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gameRepository;

        public GamesService(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _gameRepository.GetAllAsync();
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _gameRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Game game)
        {
            await _gameRepository.AddAsync(game);
        }

        public void Update(Game game)
        {
            _gameRepository.Update(game);
            _gameRepository.SaveChanges();
        }

        public void Delete(Game game)
        {
            _gameRepository.Delete(game);
        }

        public Task<bool> ExistsAsync(int id)
        {
            return _gameRepository.ExistsAsync(id);
        }
    }
}
