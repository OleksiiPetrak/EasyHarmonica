using System;
using System.Collections.Generic;

namespace EasyHarmonica.WEB.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<UserModel> Users { get; set; }
    }
}