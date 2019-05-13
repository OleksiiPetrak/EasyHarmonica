using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyHarmonica.BLL.DTO
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Info { get; set; }
        public string Tuner { get; set; }
        public TimeSpan Duration { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public IEnumerable<string> AchievementsNames { get; set; }
        public virtual ICollection<AchievementDTO> Achievements { get; set; }

        public IEnumerable<string> UsersEmails { get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }

        public string ChapterName { get; set; }
        public int ChapterId { get; set; }
        public virtual ChapterDTO Chapter { get; set; }
    }
}
