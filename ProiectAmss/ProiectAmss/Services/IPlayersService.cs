using ProiectAmss.Models;

namespace ProiectAmss.Services
{
    public interface IPlayersService
    {
        Task RegisterPlayerForEventAsync(string playerId, int eventId);
        Task<bool> IsCheckedInAtEventAsync(string playerId, int eventId);
        Task<bool> IsRegisteredForEventAsync(string playerId, int eventId);
        Task CheckInAtEvent(string playerId, int eventId);
        Task GiveBadgeToPlayer(string playerId, int badgeId);
        Task<List<Badge>> GetBadgesForPlayerAsync(string currentUserId);
    }
}
