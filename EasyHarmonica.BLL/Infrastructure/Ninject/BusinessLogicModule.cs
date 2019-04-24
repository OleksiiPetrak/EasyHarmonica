using EasyHarmonica.BLL.Interfaces;
using EasyHarmonica.BLL.Services;
using Ninject.Modules;

namespace EasyHarmonica.BLL.Infrastructure.Ninject
{
    public class BusinessLogicModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<ILessonService>().To<LessonService>();
            Bind<IAchievementService>().To<AchievementService>();
            Bind<IChapterService>().To<ChapterService>();
            Bind<INotificationService>().To<NotificationService>();
        }
    }
}
