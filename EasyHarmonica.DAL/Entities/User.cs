using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace EasyHarmonica.DAL.Entities
{
    public class User:IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
