using EasyHarmonica.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace EasyHarmonica.DAL.Identity
{
    public class EasyHarmonicaUserManager:UserManager<User>
    {
        public EasyHarmonicaUserManager(IUserStore<User> store):base(store)
        {
            
        }
    }
}
