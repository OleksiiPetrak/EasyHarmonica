using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.BLL.Interfaces;
using EasyHarmonica.WEB.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyHarmonica.WEB.Controllers
{
    public class ChapterController : Controller
    {
        private readonly IChapterService _chapterService;
        private readonly ILessonService _lessonService;

        public ChapterController(IChapterService chapterService, ILessonService lessonService)
        {
            _chapterService = chapterService;
            _lessonService = lessonService;
        }

        public ActionResult GetChapters()
        {
            if (User.Identity.IsAuthenticated)
            {
                var chaptersDto = _chapterService.GetAllChapters();
                var chaptersModel = Mapper.Map<IEnumerable<ChapterDTO>, IEnumerable<ChapterModel>>(chaptersDto);

                var lessonsDto = _lessonService.GetAllLessons();
                var lessonsModel = Mapper.Map<IEnumerable<LessonDTO>, IEnumerable<LessonModel>>(lessonsDto);

                var startModel = new StartViewModel() { Chapters = chaptersModel, Lessons = lessonsModel };

                return View(startModel);
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ViewResult EditChapter(string chapterName)
        {
            var chapterDto = _chapterService.GetChapter(chapterName);

            var chapter = Mapper.Map<ChapterDTO, ChapterModel>(chapterDto);

            return View(chapter);
        }

        [HttpPost]
        public ActionResult EditChapter()
    }
}