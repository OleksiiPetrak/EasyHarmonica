using EasyHarmonica.DAL.Entities;
using System.Collections.Generic;

namespace EasyHarmonica.BLL.DTO
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Info { get; set; }
        public string Tuner { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public int ChapterId { get; set; }
        public virtual ChapterDTO Chapter { get; set; }
    }
}
