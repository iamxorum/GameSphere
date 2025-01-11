using Microsoft.EntityFrameworkCore;
using ProiectAmss.Data;
using ProiectAmss.Models;

namespace ProiectAmss.Repositories
{
    public class BadgesRepository : IBadgesRepository
    {
        private readonly ApplicationDbContext _context;
        public BadgesRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public Task<Badge> GetBadgeById(int badgeId)
        {
            return _context.Badges.FirstOrDefaultAsync(b => b.Id == badgeId);
        }
    }
}
