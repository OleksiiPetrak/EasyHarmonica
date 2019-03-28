using EasyHarmonica.DAL.EF;
using EasyHarmonica.DAL.Entities;
using EasyHarmonica.DAL.Identity;
using EasyHarmonica.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace EasyHarmonica.DAL.Repositories
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private readonly EasyHarmonicaContext _db;

        private EasyHarmonicaUserManager _userManager;
        private EasyHarmonicaRoleManager _roleManager;

        private IRepository<ClientProfile> _clientProfiles;
        private IRepository<Achievement> _achievementRepository;
        private IRepository<Chapter> _chapteRepository;
        private IRepository<Lesson> _lessonRepository;
        private IRepository<Notification> _notificationRepository;

        public EFUnitOfWork(EasyHarmonicaContext db)
        {
            _db = db;
        }

        public EasyHarmonicaUserManager UserManager => _userManager ?? (_userManager = new EasyHarmonicaUserManager(new UserStore<User>(_db)));

        public IRepository<ClientProfile> ClientProfiles => _clientProfiles ?? (_clientProfiles = new Repository<ClientProfile>(_db));

        public EasyHarmonicaRoleManager RoleManager => _roleManager ?? (_roleManager = new EasyHarmonicaRoleManager(new RoleStore<Role>(_db)));

        public IRepository<Achievement> Achievements =>
            _achievementRepository ?? (_achievementRepository = new Repository<Achievement>(_db));

        public IRepository<Chapter> Chapters => _chapteRepository ?? (_chapteRepository = new Repository<Chapter>(_db));

        public IRepository<Lesson> Lessons => _lessonRepository ?? (_lessonRepository = new Repository<Lesson>(_db));

        public IRepository<Notification> Notifications =>
            _notificationRepository ?? (_notificationRepository = new Repository<Notification>(_db));

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
