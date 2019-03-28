using System;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.BLL.Interfaces;
using EasyHarmonica.DAL.Entities;
using EasyHarmonica.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace EasyHarmonica.BLL.Services
{
    public class ChapterService:IChapterService
    {
        private readonly IUnitOfWork _database;

        public ChapterService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public async Task CreateChapter(ChapterDTO chapterDto)
        {
            if (chapterDto == null)
            {
                throw new ArgumentNullException("Input cannot be empty");
            }

            Chapter chapter = Mapper.Map<ChapterDTO, Chapter>(chapterDto);

            _database.Chapters.Create(chapter);
            await _database.SaveAsync();
        }

        public IEnumerable<ChapterDTO> GetAllChapters()
        {
            IEnumerable<Chapter> chapters = _database.Chapters.GetAll().ToList();

            IEnumerable<ChapterDTO> chapterDtos = Mapper.Map<IEnumerable<Chapter>, IEnumerable<ChapterDTO>>(chapters);

            return chapterDtos;
        }

        public ChapterDTO GetChapter(string chapterName)
        {
            Chapter chapter = _database.Chapters.GetOne(x => x.Name == chapterName);

            if (chapter == null)
            {
                throw new ArgumentNullException($"Chapter with such name does not exist. Name: {chapterName}");
            }

            ChapterDTO chapterDto = Mapper.Map<Chapter, ChapterDTO>(chapter);
            return chapterDto;
        }

        public async Task EditChapter(ChapterDTO chapterDto)
        {
            Chapter checkChapter = _database.Chapters.GetOne(x => x.Id == chapterDto.Id);
            if (checkChapter == null)
            {
                throw new ArgumentNullException("Chapter does not exist");
            }

            chapterDto.Id = checkChapter.Id;

            Chapter chapter = Mapper.Map<ChapterDTO, Chapter>(chapterDto);

            _database.Chapters.Update(chapter);
            await _database.SaveAsync();
        }

        public async Task DeleteChapter(int id)
        {
            Chapter chapter = _database.Chapters.Get(id);
            if (chapter == null)
            {
                throw new ArgumentNullException($"Chapter with id does not exist. Id: {id} ");
            }

            _database.Chapters.Delete(chapter);
            await _database.SaveAsync();
        }
    }
}
