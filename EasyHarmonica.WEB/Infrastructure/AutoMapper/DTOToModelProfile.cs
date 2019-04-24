using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.WEB.Models;

namespace EasyHarmonica.WEB.Infrastructure.AutoMapper
{
    public class DTOToModelProfile:Profile
    {
        public DTOToModelProfile()
        {
            CreateMap<AchievementDTO, AchievementModel>();
            CreateMap<ChapterDTO, ChapterModel>();
            CreateMap<LessonDTO, LessonModel>();
            CreateMap<NotificationDTO, NotificationModel>();
            CreateMap<UserDTO, UserModel>();
        }

        public override string ProfileName => "DTOToModel";
    }
}