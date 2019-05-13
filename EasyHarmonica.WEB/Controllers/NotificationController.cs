using EasyHarmonica.BLL.Interfaces;
using System.Web.Mvc;

namespace EasyHarmonica.WEB.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IClientProfileService _clientProfileService;
        private readonly ILessonService _lessonService;

        public NotificationController(INotificationService notificationService, IClientProfileService clientProfileService,
            ILessonService lessonService)
        {
            _notificationService = notificationService;
            _clientProfileService = clientProfileService;
            _lessonService = lessonService;
        }
    }
}