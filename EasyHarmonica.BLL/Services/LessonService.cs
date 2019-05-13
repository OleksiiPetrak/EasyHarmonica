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
    public class LessonService:ILessonService
    {
        private readonly IUnitOfWork _database;

        public LessonService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public async Task CreateLesson(LessonDTO lessonDto)
        {
            if (lessonDto == null)
            {
                throw new ArgumentNullException("Input cannot be empty");
            }

            var lesson = Mapper.Map<LessonDTO, Lesson>(lessonDto);

            _database.Lessons.Create(lesson);
            await _database.SaveAsync();
        }

        public IEnumerable<LessonDTO> GetAllLessons()
        {
            IEnumerable<Lesson> lessons = _database.Lessons.GetAll().ToList();

            var lessonDtos = Mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDTO>>(lessons);

            return lessonDtos;
        }

        public LessonDTO GetLesson(string lessonName)
        {
            var lesson = _database.Lessons.GetOne(x => x.Name == lessonName);

            if (lesson == null)
            {
                throw new ArgumentNullException($"Lesson with such name does not exist. Name: {lessonName}");
            }

            var lessonDto = Mapper.Map<Lesson, LessonDTO>(lesson);
            return lessonDto;
        }

        public string GetNextLessonName(int id)
        {
            int nextLessonId = id + 1;
            var lesson = _database.Lessons.Get(nextLessonId);

            if (lesson == null)
            {
                throw new ArgumentNullException($"Lesson with such id does not exist. Name: {id}");
            }

            return lesson.Name;
        }

        public async Task EditLesson(LessonDTO lessonDto)
        {
            var checkLesson = _database.Lessons.GetOne(x => x.Id == lessonDto.Id);
            if (checkLesson == null)
            {
                throw new ArgumentNullException("Lesson does not exist");
            }

            lessonDto.Id = checkLesson.Id;

            var lesson = Mapper.Map(lessonDto,checkLesson);

            lesson.Chapter = _database.Chapters.GetOne(x => x.Name == lessonDto.ChapterName);

            lesson.Users = _database.UserManager.Users.Where(x => lessonDto.UsersEmails.Contains(x.Email)).ToList();

            lesson.Achievements =
                _database.Achievements.Find(x => lessonDto.AchievementsNames.Contains(x.Name)).ToList();

            _database.Lessons.Update(lesson);
            await _database.SaveAsync().ConfigureAwait(false);
        }

        public async Task DeleteLesson(int id)
        {
            var lesson = _database.Lessons.Get(id);
            if (lesson == null)
            {
                throw new ArgumentNullException($"Chapter with id does not exist. Id: {id} ");
            }

            _database.Lessons.Delete(lesson);
            await _database.SaveAsync();
        }
        
    }
}
