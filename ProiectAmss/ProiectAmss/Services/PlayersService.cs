using Microsoft.Extensions.Logging;
using ProiectAmss.Models;
using ProiectAmss.Repositories;

namespace ProiectAmss.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly IPlayersRepository _playersRepository;
        private readonly IPlayerEventRepository _playerEventRepository;
        private readonly IBadgesRepository _badgesRepository;
        private readonly int FIRST_GAME_BADGE_ID = 1;

        public PlayersService(IPlayersRepository playersRepository, IPlayerEventRepository playerEventRepository, IBadgesRepository badgesRepository)
        {
            _playersRepository = playersRepository;
            _playerEventRepository = playerEventRepository;
            _badgesRepository = badgesRepository;
        }

        public async Task RegisterPlayerForEventAsync(string playerId, int eventId)
        {
            var playerEvent = new PlayerEvent
            {
                PlayerId = playerId,
                EventId = eventId,
                CheckedIn = false
            };

            await _playerEventRepository.AddAsync(playerEvent);
        }

        public async Task CheckInAtEvent(string playerId, int eventId)
        {
            var playerEvent = await _playerEventRepository.GetByPlayerIdAndEventIdAsync(playerId, eventId);

            if (playerEvent == null)
            {
                throw new Exception("Player is not registered for this event");
            }
            if (playerEvent.CheckedIn)
            {
                throw new Exception("Player is already checked in");
            }

            await GiveBadgeToPlayer(playerId, FIRST_GAME_BADGE_ID);

            playerEvent.CheckedIn = true;

            _playerEventRepository.SaveChanges();
        }

        public async Task<bool> IsCheckedInAtEventAsync(string playerId, int eventId)
        {
            var playerEvent = await _playerEventRepository.GetByPlayerIdAndEventIdAsync(playerId, eventId);
            return playerEvent != null && playerEvent.CheckedIn;
        }

        public async Task<bool> IsRegisteredForEventAsync(string playerId, int eventId)
        {
            var playerEvent = await _playerEventRepository.GetByPlayerIdAndEventIdAsync(playerId, eventId);
            return playerEvent != null;
        }

        public async Task GiveBadgeToPlayer(string playerId, int badgeId)
        {
            var player = await _playersRepository.GetPlayerByIdAsync(playerId);
            var badge = await _badgesRepository.GetBadgeById(badgeId);

            if (!player.Badges.Contains(badge))
            {
                player.Badges.Add(badge);
                _playersRepository.SaveChanges();
            }
        }

        public async Task<List<Badge>> GetBadgesForPlayerAsync(string playerId)
        {
            var player = await _playersRepository.GetPlayerByIdAsync(playerId);
            return player?.Badges?.ToList() ?? [];
        }
    }
}
