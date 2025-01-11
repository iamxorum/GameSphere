using ProiectAmss.Models;

namespace ProiectAmss.Repositories
{
    public interface IPlayersRepository
    {
        Task<Player> GetPlayerByIdAsync(string id);
        void SaveChanges();
    }
}
