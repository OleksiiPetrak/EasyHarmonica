using EasyHarmonica.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyHarmonica.BLL.Interfaces
{
    public interface IAchievementService
    {
        Task CreateAchievement(AchievementDTO achievementDto);
        IEnumerable<AchievementDTO> GetAllAchievements();
        AchievementDTO GetAchievement(string achievementName);
        Task EditAchievement(AchievementDTO achievementDto);
        Task DeleteAchievement(int id);
    }
}
