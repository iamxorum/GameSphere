using Microsoft.EntityFrameworkCore;
using ProiectAmss.Data;
using ProiectAmss.Models;

namespace ProiectAmss.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly ApplicationDbContext _context;

        public GamesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Game game)
        {
            _context.Add(game);
            await _context.SaveChangesAsync();
        }

        public void Update(Game game)
        {
            _context.Update(game);
        }

        public void Delete(Game game)
        {
            _context.Games.Remove(game);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Games.AnyAsync(e => e.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }  
    }
}
