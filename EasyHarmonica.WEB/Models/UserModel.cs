using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyHarmonica.WEB.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public DateTime BirthDay { get; set; }
        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public ClientProfileModel ClientProfile { get; set; }
        public virtual ICollection<NotificationModel> Notifications { get; set; }
        public virtual ICollection<AchievementModel> Achievements { get; set; }
        public virtual ICollection<LessonModel> Lessons { get; set; }
    }
}