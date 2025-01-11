using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectAmss.Models
{
    public class Event
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Start date is requied")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100, ErrorMessage = "Location cannot be longer than 100 characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Number of participants is required")]
        public int MaxParticipants { get; set; }
        public string? OwnerId { get; set; }
        virtual public Player? Owner { get; set; }
        public int? ChosenGameId { get; set; }
        virtual public Game? ChosenGame { get; set; }

        virtual public ICollection<PlayerEvent>? PlayerEvents { get; set; }
        virtual public ICollection<Game>? Games { get; set; }

        [NotMapped]
        public int GameId { get; set; }
    }
}



