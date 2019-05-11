using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyHarmonica.WEB.Models
{
    public class CreateChapterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public string Info { get; set; }

        public List<string> LessonsNames { get; set; }
        public MultiSelectList Lessons { get; set; }
    }
}