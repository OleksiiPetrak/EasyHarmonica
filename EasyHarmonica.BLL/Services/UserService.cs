using EasyHarmonica.BLL.DTO;
using EasyHarmonica.BLL.Interfaces;
using EasyHarmonica.DAL.Entities;
using EasyHarmonica.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace EasyHarmonica.BLL.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _database;

        public UserService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            List<User> users = await _database.UserManager.Users.ToListAsync();

            var result = Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);

            return result;
        }

        public async Task<UserDTO> GetUser(string email)
        {
            User user = await _database.UserManager.FindByEmailAsync(email);

            if(user == null)
            {
                throw new ArgumentNullException($"User with email {email} does not exist");
            }

            var result = Mapper.Map<User, UserDTO>(user);

            return result;
        }

        public async Task ImproveUserData(string lessonName, string email)
        {
            var lessonsCount = _database.Lessons.GetAll().Count();
            double percent = 100 / lessonsCount;

            var clientProfile = _database.ClientProfiles.GetOne(x => x.Address == email);

            if (clientProfile == null)
            {
                throw new ArgumentNullException($"Profile with such email does not exist. Id{email}");
            }

            clientProfile.Progress += percent;
            _database.ClientProfiles.Update(clientProfile);
            await _database.SaveAsync().ConfigureAwait(false);

            var user = await _database.UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new ArgumentNullException($"User with email {email} does not exist");
            }

            var lesson = _database.Lessons.GetOne(x => x.Name == lessonName);

            lesson.Users.Add(user);

            _database.Lessons.Update(lesson);
            await _database.SaveAsync().ConfigureAwait(false);

            foreach (var achievement in lesson.Achievements)
            {
                achievement.Users.Add(user);
                _database.Achievements.Update(achievement);
            }
  
            await _database.SaveAsync().ConfigureAwait(false);
        }

        public async Task Create(UserDTO userDto)
        {
            User user = await _database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new User { Email = userDto.Email, UserName = userDto.Email };
                var result = await _database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    throw new Exception($"User with email {userDto.Email} didn't create");
                // добавляем роль
                await _database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
                ClientProfile clientProfile = new ClientProfile
                    {Id = user.Id, Address = userDto.Email, City = userDto.City, Name = userDto.Name, BirthDay = userDto.BirthDay, Registration = DateTime.Now};
                _database.ClientProfiles.Create(clientProfile);
                await _database.SaveAsync();
            }
            else
            {
                throw new Exception("User with this email already exist");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            User user = await _database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await _database.UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await _database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new Role { Name = roleName };
                    await _database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }
    }
}
