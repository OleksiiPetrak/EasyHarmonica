using EasyHarmonica.Common.Enums;
using System;
using System.Web.Mvc;

namespace EasyHarmonica.BLL.DTO
{
    public class ClientProfileDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
        public string City { get; set; }
        public double Progress { get; set; }
        public DateTime RegistrationDate { get; set; }
        public CourseComplexity CourseComplexity { get; set; }
        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public virtual UserDTO User { get; set; }
    }
}
