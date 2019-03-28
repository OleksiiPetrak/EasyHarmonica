using EasyHarmonica.DAL.Modules;
using Ninject.Modules;

namespace EasyHarmonica.BLL.Infrastructure.Ninject
{
    public class DependencyResolver
    {
        public INinjectModule[] GetModules()
        {
            return new INinjectModule[]
            {
                new DataAccessModule(),
                new BusinessLogicModule()
            };
        }
    }
}
