using System;
using System.Collections.Generic;
using EasyHarmonica.DAL.Entities;

namespace EasyHarmonica.BLL.DTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }

        public string Info { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
