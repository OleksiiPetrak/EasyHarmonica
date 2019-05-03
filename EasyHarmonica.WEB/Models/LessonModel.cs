using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyHarmonica.WEB.Models
{
    public class LessonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Info { get; set; }
        public string Tuner { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public virtual ICollection<AchievementModel> Achievements { get; set; }
        public virtual ICollection<UserModel> Users { get; set; }

        public int ChapterId { get; set; }
        public virtual ChapterModel Chapter { get; set; }
    }
}