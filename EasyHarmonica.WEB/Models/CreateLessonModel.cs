using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyHarmonica.WEB.Models
{
    public class CreateLessonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Info { get; set; }
        public string Tuner { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public IEnumerable<string> AchievementsNames { get; set; }

        public MultiSelectList Achievements { get; set; }

        public IEnumerable<string> UsersEmails { get; set; }

        public MultiSelectList Users { get; set; }

        public string ChapterName { get; set; }
        public SelectList Chapter { get; set; }
    }
}