using EasyHarmonica.Common.Enums;
using EasyHarmonica.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace EasyHarmonica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EF.EasyHarmonicaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EF.EasyHarmonicaContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name,
               new Role { Name = "Administrator" },
               new Role { Name = "User" },
               new Role { Name = "Manager" },
               new Role { Name = "Moderator" },
               new Role { Name = "Guest" }
               );

            context.SaveChanges();

            var roleUser = context.Roles.FirstOrDefault(x => x.Name == "User");
            var roleManager = context.Roles.FirstOrDefault(x => x.Name == "Manager");
            var roleAdmin = context.Roles.FirstOrDefault(x => x.Name == "Administrator");
            var roleModerator = context.Roles.FirstOrDefault(x => x.Name == "Moderator");

            context.Users.AddOrUpdate(x => x.Email,
                new User { PasswordHash = "password".GetHashCode().ToString(), UserName = "h.levy@mail.com", Email = "h.levy@mail.com" },
                new User { PasswordHash = "password".GetHashCode().ToString(), UserName = "petrak@mail.com", Email = "petrak@mail.com" },
                new User { PasswordHash = "password".GetHashCode().ToString(), UserName = "loma@mail.com", Email = "loma@mail.com" });

            context.SaveChanges();

            var howardLevy = context.Users.FirstOrDefault(x => x.Email == "h.levy@mail.com");
            var oleksiiPetrak = context.Users.FirstOrDefault(x => x.Email == "petrak@mail.com");
            var lomachenko = context.Users.FirstOrDefault(x => x.Email == "loma@mail.com");

            context.Users.AddOrUpdate(x => x.Email,
                new User
                {
                    PasswordHash = "password".GetHashCode().ToString(),
                    UserName = "h.levy@mail.com",
                    Email = "h.levy@mail.com",
                    Roles = { new IdentityUserRole { RoleId = roleManager.Id, UserId = howardLevy.Id } }
                },
                new User
                {
                    PasswordHash = "password".GetHashCode().ToString(),
                    UserName = "petrak@mail.com",
                    Email = "petrak@mail.com",
                    Roles = { new IdentityUserRole { RoleId = roleAdmin.Id, UserId = oleksiiPetrak.Id } }
                },
                new User
                {
                    PasswordHash = "password".GetHashCode().ToString(),
                    UserName = "loma@mail.com",
                    Email = "loma@mail.com",
                    Roles = { new IdentityUserRole { RoleId = roleUser.Id, UserId = lomachenko.Id } }
                });


            context.SaveChanges();

            context.ClientProfiles.AddOrUpdate(x => x.Address,
                new ClientProfile { Name = "Howard Levy", Address = "h.levy@mail.com", BirthDay = DateTime.Now.AddYears(-48), City = "LA", CourseComplexity = CourseComplexity.Hard, User = howardLevy },
                new ClientProfile { Name = "Oleksii Petrak", Address = "petrak@mail.com", BirthDay = DateTime.Now.AddYears(-21), City = "Kharkiv", CourseComplexity = CourseComplexity.Middle, User = oleksiiPetrak },
                new ClientProfile { Name = "Vasiliy Lomachenko", Address = "loma@mail.com", BirthDay = DateTime.Now.AddYears(-26), City = "Kyiv", CourseComplexity = CourseComplexity.Easy, User = lomachenko });

            context.Notifications.AddOrUpdate(x => x.Date,
                new Notification { Date = DateTime.Now.AddMinutes(15), Info = "Don't forget to practice!", Users = new List<User> { lomachenko } },
                new Notification { Date = DateTime.Now.AddMinutes(30), Info = "You lost your time!", Users = new List<User> { lomachenko } },
                new Notification { Date = DateTime.Now.AddMinutes(60), Info = "New chapter is available!", Users = new List<User> { lomachenko } });

            context.Chapters.AddOrUpdate(x => x.Name,
                new Chapter { Info = "Chapter contain basic knowledge for future harper", Name = "Start" },
                new Chapter { Info = "Chapter contain key knowledge for frequent play", Name = "Essential" },
                new Chapter
                {
                    Info = "Chapter contain additional knowledge for professional musician",
                    Name = "Experience"
                });

            context.SaveChanges();

            var startChapter = context.Chapters.FirstOrDefault(x => x.Name == "Start");

            context.Lessons.AddOrUpdate(x => x.Name,
                new Lesson
                {
                    Name = "How to choice a harmonica",
                    Info = "Make your choice",
                    Tuner = "http://modusmusic.ru/info/hromaticheskiy-tyuner-dlja-nastrojki-muzykalnyh-instrumentov/",
                    Chapter = startChapter,
                    Users = new List<User> { lomachenko }
                },
                new Lesson
                {
                    Name = "How to take clear note",
                    Info = "You should to practicing more",
                    Tuner = "http://modusmusic.ru/info/hromaticheskiy-tyuner-dlja-nastrojki-muzykalnyh-instrumentov/",
                    Chapter = startChapter,
                    Users = new List<User> { lomachenko }
                },
                new Lesson
                {
                    Name = "How to play an accords",
                    Info = "You need just take several wholes",
                    Tuner = "http://modusmusic.ru/info/hromaticheskiy-tyuner-dlja-nastrojki-muzykalnyh-instrumentov/",
                    Chapter = startChapter,
                    Users = new List<User> { lomachenko }
                });

            context.SaveChanges();

            var clearNote = context.Lessons.FirstOrDefault(x => x.Name == "How to take clear note");

            context.Achievements.AddOrUpdate(x => x.Name,
                new Achievement { Name = "Fast learner", Date = DateTime.Now, PromotionPercentage = 12.0, Timeliness = true, Users = new List<User> { lomachenko }, LessonId = clearNote.Id },
                new Achievement { Name = "Talent!", Date = DateTime.Now, PromotionPercentage = 12.5, Timeliness = true, Users = new List<User> { lomachenko }, LessonId = clearNote.Id },
                new Achievement { Name = "All in time", Date = DateTime.Now, PromotionPercentage = 13.0, Timeliness = true, Users = new List<User> { lomachenko }, LessonId = clearNote.Id });
        }
    }
}
