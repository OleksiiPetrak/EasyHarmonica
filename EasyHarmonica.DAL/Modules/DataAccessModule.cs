using EasyHarmonica.DAL.EF;
using EasyHarmonica.DAL.Interfaces;
using EasyHarmonica.DAL.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace EasyHarmonica.DAL.Modules
{
    public class DataAccessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
            Bind<EasyHarmonicaContext>().ToSelf().InRequestScope();
        }
    }
}
