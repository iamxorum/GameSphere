using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProiectAmss.Models;

namespace ProiectAmss.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerEvent> PlayerEvents { get; set; }
        public DbSet<Badge> Badges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // definire primary key compus
            modelBuilder.Entity<PlayerEvent>()
                .HasKey(ab => new { ab.Id, ab.PlayerId, ab.EventId });
            // definire relatii cu modelele User si User
            modelBuilder.Entity<PlayerEvent>()
                .HasOne(ab => ab.Player)
                .WithMany(ab => ab.PlayerEvents)
                .HasForeignKey(ab => ab.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayerEvent>()
                .HasOne(ab => ab.Event)
                .WithMany(ab => ab.PlayerEvents)
                .HasForeignKey(ab => ab.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                .HasOne(a => a.ChosenGame)
                .WithMany(a => a.ChosenGameEvents)
                .HasForeignKey(a => a.ChosenGameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
