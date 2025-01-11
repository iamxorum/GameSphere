using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectAmss.Models
{
    public class Player : IdentityUser
    {
        virtual public ICollection<PlayerEvent>? PlayerEvents { get; set; }
        virtual public ICollection<Event>? CreatedEvents { get; set; }
        virtual public ICollection<Badge>? Badges { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? AllRoles { get; set; }
    }
}
