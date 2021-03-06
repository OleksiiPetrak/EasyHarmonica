﻿using AutoMapper;
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

            Lesson lesson = Mapper.Map<LessonDTO, Lesson>(lessonDto);

            _database.Lessons.Create(lesson);
            await _database.SaveAsync();
        }

        public IEnumerable<LessonDTO> GetAllLessons()
        {
            IEnumerable<Lesson> lessons = _database.Lessons.GetAll().ToList();

            IEnumerable<LessonDTO> lessonDtos = Mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonDTO>>(lessons);

            return lessonDtos;
        }

        public LessonDTO GetLesson(string lessonName)
        {
            Lesson lesson = _database.Lessons.GetOne(x => x.Name == lessonName);

            if (lesson == null)
            {
                throw new ArgumentNullException($"Lesson with such name does not exist. Name: {lessonName}");
            }

            LessonDTO lessonDto = Mapper.Map<Lesson, LessonDTO>(lesson);
            return lessonDto;
        }

        public async Task EditLesson(LessonDTO lessonDto)
        {
            Lesson checkLesson = _database.Lessons.GetOne(x => x.Id == lessonDto.Id);
            if (checkLesson == null)
            {
                throw new ArgumentNullException("Lesson does not exist");
            }

            lessonDto.Id = checkLesson.Id;

            Lesson lesson = Mapper.Map<LessonDTO, Lesson>(lessonDto);

            _database.Lessons.Update(lesson);
            await _database.SaveAsync();
        }

        public async Task DeleteLesson(int id)
        {
            Lesson lesson = _database.Lessons.Get(id);
            if (lesson == null)
            {
                throw new ArgumentNullException($"Chapter with id does not exist. Id: {id} ");
            }

            _database.Lessons.Delete(lesson);
            await _database.SaveAsync();
        }
    }
}
