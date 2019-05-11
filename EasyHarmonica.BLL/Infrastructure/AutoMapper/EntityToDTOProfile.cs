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
            CreateMap<ClientProfile, ClientProfileDTO>();
            CreateMap<Achievement, AchievementDTO>();
            CreateMap<Chapter, ChapterDTO>()
                .ForMember(x => x.LessonsNames, opt => opt.Ignore());
            CreateMap<Lesson, LessonDTO>();
            CreateMap<Notification, NotificationDTO>();
        }

        public override string ProfileName => "EntityToDTO";
    }
}
