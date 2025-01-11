using Microsoft.EntityFrameworkCore;
using ProiectAmss.Data;
using ProiectAmss.Models;
using ProiectAmss.Repositories;

public class EventsRepository : IEventsRepository
{
    private readonly ApplicationDbContext _context;

    public EventsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task<Event> GetByIdAsync(int id)
    {
        return await _context.Events.Include("Games").Include("Owner").Include("PlayerEvents.Player").FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Event entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public void Update(Event entity)
    {
        _context.Update(entity);
    }

    public void Delete(Event entity)
    {
        _context.Events.Remove(entity);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Events.AnyAsync(e => e.Id == id);
    }

    public void SaveChanges() {
        _context.SaveChanges();
    }
}