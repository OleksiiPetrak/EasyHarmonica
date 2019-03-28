using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.BLL.Interfaces;
using EasyHarmonica.DAL.Entities;
using EasyHarmonica.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHarmonica.BLL.Services
{
    public class AchievementService:IAchievementService
    {
        private readonly IUnitOfWork _database;

        public AchievementService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public async Task CreateAchievement(AchievementDTO achievementDto)
        {
            if (achievementDto == null)
            {
                throw new ArgumentNullException("Input cannot be empty");
            }

            Achievement achievement = Mapper.Map<AchievementDTO, Achievement>(achievementDto);

            _database.Achievements.Create(achievement);
            await _database.SaveAsync();
        }

        public IEnumerable<AchievementDTO> GetAllAchievements()
        {
            IEnumerable<Achievement> achievements = _database.Achievements.GetAll().ToList();

            IEnumerable<AchievementDTO> achievementDtos =
                Mapper.Map<IEnumerable<Achievement>, IEnumerable<AchievementDTO>>(achievements);

            return achievementDtos;
        }

        public AchievementDTO GetAchievement(string achievementName)
        {
            Achievement achievement = _database.Achievements.GetOne(x => x.Name == achievementName);

            if (achievement == null)
            {
                throw new ArgumentNullException($"Achievement with such name does not exist. Name: {achievementName}");
            }

            AchievementDTO achievementDto = Mapper.Map<Achievement, AchievementDTO>(achievement);
            return achievementDto;
        }

        public async Task EditAchievement(AchievementDTO achievementDto)
        {
            Achievement checkAchievement = _database.Achievements.GetOne(x => x.Id == achievementDto.Id);
            if (checkAchievement == null)
            {
                throw new ArgumentNullException("Publisher does not exist");
            }

            achievementDto.Id = checkAchievement.Id;

            Achievement achievement = Mapper.Map<AchievementDTO, Achievement>(achievementDto);

            _database.Achievements.Update(achievement);
            await _database.SaveAsync();
        }

        public async Task DeleteAchievement(int id)
        {
            Achievement achievement = _database.Achievements.Get(id);
            if (achievement == null)
            {
                throw new ArgumentNullException($"Achievement with id does not exist. Id: {id} ");
            }

            _database.Achievements.Delete(achievement);
            await _database.SaveAsync();
        }
    }
}
