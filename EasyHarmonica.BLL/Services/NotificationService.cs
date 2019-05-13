using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.BLL.Interfaces;
using EasyHarmonica.DAL.Entities;
using EasyHarmonica.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHarmonica.BLL.Services
{
    public class NotificationService: INotificationService
    {
        private readonly IUnitOfWork _database;

        public NotificationService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public async Task CreateNotification(NotificationDTO notificationDto)
        {
            if (notificationDto == null)
            {
                throw new ArgumentNullException("Input cannot be empty");
            }

            Notification notification = Mapper.Map<NotificationDTO, Notification>(notificationDto);

            _database.Notifications.Create(notification);
            await _database.SaveAsync();
        }

        public IEnumerable<NotificationDTO> GetAllNotifications()
        {
            IEnumerable<Notification> notifications = _database.Notifications.GetAll().ToList();

            IEnumerable<NotificationDTO> notificationDtos =
                Mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationDTO>>(notifications);

            return notificationDtos;
        }

        public NotificationDTO GetNotification(int id)
        {
            Notification notification = _database.Notifications.GetOne(x => x.Id == id);

            if (notification == null)
            {
                throw new ArgumentNullException($"Notification with such id does not exist. Name: {id}");
            }

            NotificationDTO notificationDto = Mapper.Map<Notification, NotificationDTO>(notification);
            return notificationDto;
        }

        private bool CheckForNotificationExisting(string info)
        {
            Notification notification = _database.Notifications.GetOne(x => x.Info == info);

            if (notification == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task EditNotification(NotificationDTO notificationDto)
        {
            Notification checkNotification = _database.Notifications.GetOne(x => x.Id == notificationDto.Id);
            if (checkNotification == null)
            {
                throw new ArgumentNullException("Notification does not exist");
            }

            notificationDto.Id = checkNotification.Id;

            Notification notification = Mapper.Map<NotificationDTO, Notification>(notificationDto);

            _database.Notifications.Update(notification);
            await _database.SaveAsync();
        }

        public async Task DeleteNotification(int id)
        {
            Notification notification = _database.Notifications.Get(id);
            if (notification == null)
            {
                throw new ArgumentNullException($"Notification with id does not exist. Id: {id} ");
            }

            _database.Notifications.Delete(notification);
            await _database.SaveAsync();
        }

        public async Task CheckForNotification(string email)
        {
            var registrationDate = _database.ClientProfiles.GetOne(x => x.Address == email).RegistrationDate;
            var currentDate = DateTime.Now;
            DateTime summaryDate;
            NotificationDTO notification = null;

            var lessonList = _database.Lessons.GetAll();

            foreach (var lesson in lessonList)
            {
                summaryDate = registrationDate + lesson.Duration;
                if (summaryDate > currentDate)
                {
                    break;
                }
                notification = new NotificationDTO { Date = DateTime.Now, Info = $"It's time to study lesson {lesson.Name}" };                                
            }

            var user = await _database.UserManager.FindByEmailAsync(email);
            var userDto = Mapper.Map<User, UserDTO>(user);

            if (notification == null)
            {
                notification = new NotificationDTO { Date = DateTime.Now, Info = "You are professional harper)", Users = {userDto} };
            }

            var checkNotification = CheckForNotificationExisting(notification.Info);
            if (!checkNotification)
            {
                await CreateNotification(notification);
            }
        }
    }
}
