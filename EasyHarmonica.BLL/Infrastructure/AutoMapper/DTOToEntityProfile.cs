using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.DAL.Entities;

namespace EasyHarmonica.BLL.Infrastructure.AutoMapper
{
    public class DTOToEntityProfile: Profile
    {
        public DTOToEntityProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<AchievementDTO, Achievement>();
            CreateMap<ChapterDTO, Chapter>();
            CreateMap<LessonDTO, Lesson>();
            CreateMap<NotificationDTO, Notification>();
        }

        public override string ProfileName => "DTOToEntity";
    }
}
