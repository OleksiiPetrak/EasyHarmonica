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
            CreateMap<ChapterModel, ChapterDTO>();
            CreateMap<LessonModel, LessonDTO>();
            CreateMap<NotificationModel, NotificationDTO>();
            CreateMap<UserModel, UserDTO>();
        }

        public override string ProfileName => "ModelToDTO";
    }
}