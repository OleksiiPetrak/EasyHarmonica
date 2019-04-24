using System.Collections.Generic;

namespace EasyHarmonica.WEB.Models
{
    public class StartViewModel
    {
        public IEnumerable<LessonModel> Lessons { get; set; }
        public IEnumerable<ChapterModel> Chapters { get; set; }
    }
}