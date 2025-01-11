using Microsoft.EntityFrameworkCore;
using ProiectAmss.Data;
using ProiectAmss.Models;

namespace ProiectAmss.Repositories
{
    public class PlayerEventRepository : IPlayerEventRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerEventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayerEvent>> GetAllAsync()
        {
            return await _context.PlayerEvents.ToListAsync();
        }

        public async Task<PlayerEvent> GetByIdAsync(int id)
        {
            return await _context.PlayerEvents.FindAsync(id);
        }

        public async Task AddAsync(PlayerEvent playerEvent)
        {
            _context.PlayerEvents.Add(playerEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<PlayerEvent> GetByPlayerIdAndEventIdAsync(string playerId, int eventId)
        {
           return await _context.PlayerEvents.FirstOrDefaultAsync(pe => pe.PlayerId == playerId && pe.EventId == eventId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
