using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using EasyHarmonica.Common.Enums;

namespace EasyHarmonica.DAL.Entities
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime BirthDay { get; set; }

        public string City { get; set; }

        public double Progress { get; set; }

        public DateTime RegistrationDate { get; set; }

        public CourseComplexity CourseComplexity { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue=false)]
        public string ImageMimeType { get; set; }

        public virtual User User { get; set; }
    }
}
