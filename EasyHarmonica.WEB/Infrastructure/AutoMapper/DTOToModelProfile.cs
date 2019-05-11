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
            CreateMap<ChapterDTO, CreateChapterModel>()
                .ForMember(x => x.Lessons, opt => opt.Ignore());
            CreateMap<ChapterDTO, ChapterModel>();
            CreateMap<LessonDTO, CreateLessonModel>()
                .ForMember(x => x.Achievements, opt => opt.Ignore())
                .ForMember(x => x.Users, opt => opt.Ignore())
                .ForMember(x => x.Chapter, opt => opt.Ignore());
            CreateMap<LessonDTO, LessonModel>();
            CreateMap<NotificationDTO, NotificationModel>();
        }

        public override string ProfileName => "DTOToModel";
    }
}