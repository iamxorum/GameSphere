using Microsoft.EntityFrameworkCore;
using ProiectAmss.Data;
using ProiectAmss.Models;

namespace ProiectAmss.Repositories
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Player> GetPlayerByIdAsync(string id)
        {
            return await _context.Players.Include("Badges").FirstOrDefaultAsync(player => player.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
