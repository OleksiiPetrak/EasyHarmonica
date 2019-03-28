using EasyHarmonica.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyHarmonica.BLL.Interfaces
{
    public interface INotificationService
    {
        Task CreateNotification(NotificationDTO notificationDto);
        IEnumerable<NotificationDTO> GetAllNotifications();
        NotificationDTO GetNotification(int id);
        Task EditNotification(NotificationDTO notificationDto);
        Task DeleteNotification(int id);
    }
}
