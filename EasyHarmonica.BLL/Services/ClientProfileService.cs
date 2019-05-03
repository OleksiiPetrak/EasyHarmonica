using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.BLL.Interfaces;
using EasyHarmonica.DAL.Entities;
using EasyHarmonica.DAL.Interfaces;

namespace EasyHarmonica.BLL.Services
{
    public class ClientProfileService: IClientProfileService
    {
        private readonly IUnitOfWork _database;

        public ClientProfileService(IUnitOfWork database)
        {
            _database = database;
        }

        public Task CreateProfile(ClientProfileDTO clientProfileDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientProfileDTO> GetAllClientProfiles()
        {
            throw new NotImplementedException();
        }

        public ClientProfileDTO GetClientProfile(string email)
        {
            var clientProfile = _database.ClientProfiles.GetOne(x => x.Address == email);

            if (clientProfile == null)
            {
                throw new ArgumentNullException($"Profile with such email does not exist. Id{email}");
            }

            ClientProfileDTO clientProfileDto = Mapper.Map<ClientProfile, ClientProfileDTO>(clientProfile);
            return clientProfileDto;
        }

        public Task EditClientProfile(ClientProfileDTO clientProfileDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClientProfile(string id)
        {
            throw new NotImplementedException();
        }
    }
}
