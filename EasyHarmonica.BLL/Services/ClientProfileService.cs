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

            var clientProfileDto = Mapper.Map<ClientProfile, ClientProfileDTO>(clientProfile);
            return clientProfileDto;
        }

        public async Task EditClientProfile(ClientProfileDTO clientProfileDto)
        {
            var checkUserProfile = _database.ClientProfiles.GetOne(x => x.Address == clientProfileDto.Address);

            if (checkUserProfile == null)
            {
                throw new ArgumentNullException("Client profile is null");
            }

            clientProfileDto.Id = checkUserProfile.Id;

            var clientProfileEntity = Mapper.Map(clientProfileDto,checkUserProfile);

            _database.ClientProfiles.Update(clientProfileEntity);
            await _database.SaveAsync().ConfigureAwait(false);
        }

        public Task DeleteClientProfile(string id)
        {
            throw new NotImplementedException();
        }
    }
}
