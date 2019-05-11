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
            CreateMap<CreateLessonModel, LessonDTO>()
                .ForMember(x => x.Achievements, opt => opt.Ignore())
                .ForMember(x => x.Users, opt => opt.Ignore())
                .ForMember(x => x.Chapter, opt => opt.Ignore())
                .ForMember(x=>x.ChapterId, opt=>opt.Ignore());
            CreateMap<LessonModel, LessonDTO>()
                .ForMember(x => x.AchievementsNames, opt => opt.Ignore())
                .ForMember(x => x.UsersEmails, opt => opt.Ignore());
            CreateMap<NotificationModel, NotificationDTO>();
        }

        public override string ProfileName => "ModelToDTO";
    }
}