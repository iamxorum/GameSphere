using System.ComponentModel.DataAnnotations;

namespace ProiectAmss.Models
{
    public class Badge
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        virtual public ICollection<Player>? Players { get; set; }
    }
}
