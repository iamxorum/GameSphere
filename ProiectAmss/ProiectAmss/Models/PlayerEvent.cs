using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectAmss.Models
{
    public class PlayerEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public string? PlayerId { set; get; }
        public int? EventId { set; get; }
        virtual public Player? Player { set; get; }
        virtual public Event? Event { set; get; }
        public bool CheckedIn { set; get; }
    }
}
