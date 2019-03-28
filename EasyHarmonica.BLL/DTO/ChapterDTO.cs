using EasyHarmonica.DAL.Entities;
using System.Collections.Generic;

namespace EasyHarmonica.BLL.DTO
{
    public class ChapterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Info { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
