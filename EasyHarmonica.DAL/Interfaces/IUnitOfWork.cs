using EasyHarmonica.DAL.Entities;
using EasyHarmonica.DAL.Identity;
using System.Threading.Tasks;

namespace EasyHarmonica.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        EasyHarmonicaUserManager UserManager { get; }
        IRepository<ClientProfile> ClientProfiles { get; }
        EasyHarmonicaRoleManager RoleManager { get; }
        IRepository<Achievement> Achievements { get; }
        IRepository<Chapter> Chapters { get; }
        IRepository<Lesson> Lessons { get; }
        IRepository<Notification> Notifications { get; }
        Task SaveAsync();
    }
}
