using System;
using System.Web.Mvc;

namespace EasyHarmonica.BLL.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Role { get; set; }
        public DateTime BirthDay { get; set; }
        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
