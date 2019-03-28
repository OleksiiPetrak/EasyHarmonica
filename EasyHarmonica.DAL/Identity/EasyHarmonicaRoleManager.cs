using EasyHarmonica.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace EasyHarmonica.DAL.Identity
{
    public class EasyHarmonicaRoleManager:RoleManager<Role>
    {
        public EasyHarmonicaRoleManager(IRoleStore<Role, string> store):base(store)
        {
            
        }
    }
}
