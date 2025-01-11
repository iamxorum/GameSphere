using System.ComponentModel.DataAnnotations;

namespace ProiectAmss.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Maximum number of participants is required")]
        public int MaxPlayers { get; set; }

        [Required(ErrorMessage = "Rules are required")]
        public string Rules { get; set; }

        virtual public ICollection<Event>? ChosenGameEvents { get; set; }
        virtual public ICollection<Event>? Events { get; set; }
    }
}
