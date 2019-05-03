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
            CreateMap<UserDTO, UserModel>();
            CreateMap<ClientProfileDTO, ClientProfileModel>();
            CreateMap<ChapterDTO, ChapterModel>();
            CreateMap<LessonDTO, LessonModel>();
            CreateMap<NotificationDTO, NotificationModel>();
        }

        public override string ProfileName => "DTOToModel";
    }
}