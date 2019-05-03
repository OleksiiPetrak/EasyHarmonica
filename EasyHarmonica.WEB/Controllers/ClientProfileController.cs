using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.BLL.Interfaces;
using EasyHarmonica.WEB.Models;
using System;
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
            ClientProfileDTO clientProfileDto = _clientProfileService.GetClientProfile(email);
            if (clientProfileDto == null)
            {
                throw new ArgumentNullException($"User with email {email} does not exist");
            }

            var clientProfile = Mapper.Map<ClientProfileDTO, ClientProfileModel>(clientProfileDto);
            return View(clientProfile);
        }
    }
}