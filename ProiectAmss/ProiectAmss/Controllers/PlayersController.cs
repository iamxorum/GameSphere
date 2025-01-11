using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProiectAmss.Models;
using ProiectAmss.Repositories;
using ProiectAmss.Services;


namespace ProiectAmss.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayersService _playersService;
        private readonly UserManager<Player> _userManager;

        public PlayersController(IPlayersService playersService, UserManager<Player> userManager)
        {
            _playersService = playersService;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register(int eventId)
        {
            var currentUserId = _userManager.GetUserId(User);
            await _playersService.RegisterPlayerForEventAsync(currentUserId, eventId);

            return RedirectToAction("Index", "Events");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CheckIn(int eventId)
        {
            var currentUserId = _userManager.GetUserId(User);
            try
            {
                await _playersService.CheckInAtEvent(currentUserId, eventId);
                return RedirectToAction("Details", "Events", new { id = eventId });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public async Task<IActionResult> MyBadges() {
            var currentUserId = _userManager.GetUserId(User);
            List<Badge> badges = await _playersService.GetBadgesForPlayerAsync(currentUserId);
            return View(badges);
        }
    }
}
