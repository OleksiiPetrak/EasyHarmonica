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
        }
    }
}
