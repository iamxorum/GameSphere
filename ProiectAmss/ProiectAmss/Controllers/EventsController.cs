using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectAmss.Models;
using ProiectAmss.Services;

public class EventsController : Controller
{
    private readonly IEventsService _eventsService;
    private readonly IGamesService _gamesService;
    private readonly IPlayersService _playersService;
    private readonly UserManager<Player> _userManager;

    public EventsController(IEventsService eventService, IGamesService gamesService, IPlayersService playersService, UserManager<Player> userManager)
    {
        _eventsService = eventService;
        _gamesService = gamesService;
        _playersService = playersService;
        _userManager = userManager;
    }

    // GET: Events
    public async Task<IActionResult> Index()
    {
        var events = await _eventsService.GetAllAsync();
        return View(events);
    }

    // GET: Events/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var @event = await _eventsService.GetByIdAsync(id.Value);
        if (@event == null)
        {
            return NotFound();
        }

        await SetUiAccessVariables(id.Value);

        return View(@event);
    }

    // GET: Events/Create
    [Authorize]
    public async Task<IActionResult> Create()
    {
        var allGames = await _gamesService.GetAllAsync();
        ViewBag.Games = CreateGameSelectList(allGames);
        return View();
    }

    // POST: Events/Create
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(Event @event)
    {
        if (ModelState.IsValid)
        {
            string currentUserId = _userManager.GetUserId(User);
            await _eventsService.AddAsync(@event, currentUserId);
            return RedirectToAction(nameof(Index));
        }

        var allGames = await _gamesService.GetAllAsync();
        ViewBag.Games = CreateGameSelectList(allGames);
        return View(@event);
    }

    // GET: Events/AddGame/5
    [Authorize]
    public async Task<IActionResult> AddGame(int? id)
    {
        var allGames = await _gamesService.GetAllAsync();
        ViewBag.Games = CreateGameSelectList(allGames);
        return View(id);
    }

    // POST: Events/AddGame/5
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddGame(int eventId, int gameId)
    {
        await _eventsService.AddGameToEventAsync(eventId, gameId);
        return RedirectToAction("Details", "Events", new { id = eventId });
    }

    // GET: Events/ChooseGame/5
    [Authorize]
    public async Task<IActionResult> ChooseGame(int id)
    {
        var userId = _userManager.GetUserId(User);
        var @event = await _eventsService.GetByIdAsync(id);
        if (@event.OwnerId != userId)
        {
            return Forbid();
        }
        ViewBag.Games = CreateGameSelectList(@event.Games);
        return View(id);
    }

    // POST: Events/AddGame/5
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ChooseGame(int eventId, int gameId)
    {
        var userId = _userManager.GetUserId(User);
        var @event = await _eventsService.GetByIdAsync(eventId);
        if (@event.OwnerId != userId)
        {
            return Forbid();
        }
        await _eventsService.ChooseGameForEventAsync(eventId, gameId);
        return RedirectToAction("Details", "Events", new { id = eventId });
    }

    // GET: Events/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var @event = await _eventsService.GetByIdAsync(id.Value);
        if (@event == null)
        {
            return NotFound();
        }
        return View(@event);
    }

    // POST: Events/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Event @event)
    {
        if (id != @event.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _eventsService.Update(@event);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _eventsService.ExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(@event);
    }

    // GET: Events/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var @event = await _eventsService.GetByIdAsync(id.Value);
        if (@event == null)
        {
            return NotFound();
        }

        return View(@event);
    }

    // POST: Events/Delete/5
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var @event = await _eventsService.GetByIdAsync(id);
        if (@event != null)
        {
            _eventsService.Delete(@event);
        }

        return RedirectToAction(nameof(Index));
    }

    private IEnumerable<SelectListItem> CreateGameSelectList(IEnumerable<Game> games)
    {
        var selectList = new List<SelectListItem>();

        foreach (var game in games)
        {
            selectList.Add(new SelectListItem
            {
                Value = game.Id.ToString(),
                Text = game.Name.ToString()
            });
        }

        return selectList;
    }

    private async Task SetUiAccessVariables(int eventId)
    {
        string currentUserId = _userManager.GetUserId(User);
        ViewBag.isCheckedIn = currentUserId != null && _playersService.IsCheckedInAtEventAsync(currentUserId, eventId).Result;
        ViewBag.isRegistered = currentUserId != null && _playersService.IsRegisteredForEventAsync(currentUserId, eventId).Result;
        ViewBag.isOwner = currentUserId != null && _eventsService.GetByIdAsync(eventId).Result.OwnerId == currentUserId;
    }
}