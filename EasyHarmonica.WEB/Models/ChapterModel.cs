using System.Collections.Generic;

namespace EasyHarmonica.WEB.Models
{
    public class ChapterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Info { get; set; }
        public virtual ICollection<LessonModel> Lessons { get; set; }
    }
}