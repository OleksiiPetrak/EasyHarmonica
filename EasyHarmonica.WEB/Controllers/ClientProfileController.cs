using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.BLL.Interfaces;
using EasyHarmonica.WEB.Models;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyHarmonica.WEB.Controllers
{
    public class ClientProfileController : Controller
    {
        private readonly IClientProfileService _clientProfileService;

        public ClientProfileController(IClientProfileService clientProfileService)
        {
            _clientProfileService = clientProfileService;
        }

        [HttpGet]
        public ViewResult GetUserInfo(string email)
        {
            var clientProfileDto = _clientProfileService.GetClientProfile(email);
            if (clientProfileDto == null)
            {
                throw new ArgumentNullException($"User with email {email} does not exist");
            }

            var clientProfile = Mapper.Map<ClientProfileDTO, ClientProfileModel>(clientProfileDto);
            return View(clientProfile);
        }

        [HttpGet]
        public ViewResult EditUserInfo(string email)
        {
            email = User.Identity.Name;
            var clientProfileDto = _clientProfileService.GetClientProfile(email);
            if (clientProfileDto == null)
            {
                throw new ArgumentNullException($"User with email {email} does not exist");
            }

            var clientProfile = Mapper.Map<ClientProfileDTO, ClientProfileModel>(clientProfileDto);
            return View(clientProfile);
        }

        [HttpPost]
        public async Task<ActionResult> EditUserInfo(ClientProfileModel clientProfile, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    clientProfile.ImageMimeType = image.ContentType;
                    clientProfile.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(clientProfile.ImageData, 0, image.ContentLength);
                }
                var clientDto = Mapper.Map<ClientProfileModel, ClientProfileDTO>(clientProfile);

                await _clientProfileService.EditClientProfile(clientDto).ConfigureAwait(false);

                return RedirectToAction("GetUserInfo", new { email = User.Identity.Name });
            }

            return View(clientProfile);
        }

        public FileContentResult GetImage(string email)
        {
            var clientProfile = _clientProfileService.GetClientProfile(email);
            return clientProfile.ImageMimeType != null ? File(clientProfile.ImageData, clientProfile.ImageMimeType) : null;
        }
    }
}