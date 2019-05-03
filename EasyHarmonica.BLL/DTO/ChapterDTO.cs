using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyHarmonica.BLL.DTO
{
    public class ChapterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public string Info { get; set; }
        public virtual ICollection<LessonDTO> Lessons { get; set; }
    }
}
