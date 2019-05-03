using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.BLL.Interfaces;
using EasyHarmonica.WEB.Models;
using System;
using System.Threading.Tasks;
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
        public ViewResult EditUserInfo(string email = "petrak@mail.com")
        {
            var clientProfileDto = _clientProfileService.GetClientProfile(email);
            if (clientProfileDto == null)
            {
                throw new ArgumentNullException($"User with email {email} does not exist");
            }

            var clientProfile = Mapper.Map<ClientProfileDTO, ClientProfileModel>(clientProfileDto);
            return View(clientProfile);
        }

        [HttpPost]
        public async Task<ActionResult> EditUserInfo(ClientProfileModel clientProfile)
        {
            if (ModelState.IsValid)
            {
                var clientDto = Mapper.Map<ClientProfileModel, ClientProfileDTO>(clientProfile);

                await _clientProfileService.EditClientProfile(clientDto).ConfigureAwait(false);

                return RedirectToAction("GetUserInfo", new {email = User.Identity.Name});
            }

            return View(clientProfile);
        }
    }
}