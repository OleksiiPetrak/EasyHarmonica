using EasyHarmonica.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyHarmonica.BLL.Interfaces
{
    public interface IClientProfileService
    {
        Task CreateProfile(ClientProfileDTO clientProfileDto);
        IEnumerable<ClientProfileDTO> GetAllClientProfiles();
        ClientProfileDTO GetClientProfile(string email);
        Task EditClientProfile(ClientProfileDTO clientProfileDto);
        Task DeleteClientProfile(string email);
    }
}
