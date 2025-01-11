using ProiectAmss.Models;

namespace ProiectAmss.Repositories
{
    public interface IBadgesRepository
    {
        Task<Badge> GetBadgeById(int badgeId);
    }
}
