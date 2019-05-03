using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.WEB.Models;

namespace EasyHarmonica.WEB.Infrastructure.AutoMapper
{
    public class ModelToDTOProfile:Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<AchievementModel, AchievementDTO>();
            CreateMap<UserModel, UserDTO>();
            CreateMap<ClientProfileModel, ClientProfileDTO>();
            CreateMap<ChapterModel, ChapterDTO>();
            CreateMap<LessonModel, LessonDTO>();
            CreateMap<NotificationModel, NotificationDTO>();
        }

        public override string ProfileName => "ModelToDTO";
    }
}