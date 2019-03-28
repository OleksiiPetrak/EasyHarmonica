using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.DAL.Entities;

namespace EasyHarmonica.BLL.Infrastructure.AutoMapper
{
    public class EntityToDTOProfile:Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Achievement, AchievementDTO>();
            CreateMap<Chapter, ChapterDTO>();
            CreateMap<Lesson, LessonDTO>();
            CreateMap<Notification, NotificationDTO>();
        }

        public override string ProfileName => "EntityToDTO";
    }
}
