using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.BLL.Interfaces;
using EasyHarmonica.WEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyHarmonica.WEB.Controllers
{
    public class ChapterController : Controller
    {
        private readonly IChapterService _chapterService;
        private readonly ILessonService _lessonService;
        private readonly INotificationService _notificationService;


        public ChapterController(IChapterService chapterService, ILessonService lessonService, INotificationService notificationService)
        {
            _chapterService = chapterService;
            _lessonService = lessonService;
            _notificationService = notificationService;
        }

        public async Task<ActionResult> GetChapters()
        {
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Identity.Name;

                var chaptersDto = _chapterService.GetAllChapters();
                var chaptersModel = Mapper.Map<IEnumerable<ChapterDTO>, IEnumerable<ChapterModel>>(chaptersDto);

                var lessonsDto = _lessonService.GetAllLessons();
                var lessonsModel = Mapper.Map<IEnumerable<LessonDTO>, IEnumerable<LessonModel>>(lessonsDto);

                var startModel = new StartViewModel() { Chapters = chaptersModel, Lessons = lessonsModel };

                await _notificationService.CheckForNotification(email);

                return View(startModel);
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ViewResult EditChapter(string chapterName)
        {
            var chapterDto = _chapterService.GetChapter(chapterName);

            var chapter = Mapper.Map<ChapterDTO, CreateChapterModel>(chapterDto);

            var lessonsNames = new List<string>();

            foreach(var lesson in chapterDto.Lessons)
            {
                lessonsNames.Add(lesson.Name);
            }

            chapter.LessonsNames = lessonsNames;

            var result = InitializeCreateChapterModel(chapter);

            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> EditChapter(CreateChapterModel chapter, HttpPostedFileBase image)
        {
            if(ModelState.IsValid)
            {
                if(image!=null)
                {
                    chapter.ImageMimeType = image.ContentType;
                    chapter.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(chapter.ImageData, 0, image.ContentLength);
                }

                var chapterDto = Mapper.Map<CreateChapterModel, ChapterDTO>(chapter);
                await _chapterService.EditChapter(chapterDto).ConfigureAwait(false);

                return RedirectToAction("GetChapters");
            }

            return View(chapter);
        }

        private CreateChapterModel InitializeCreateChapterModel(CreateChapterModel model)
        {
            var lessonDtos = _lessonService.GetAllLessons();

            model.Lessons = new MultiSelectList(lessonDtos, "Name", "Name");

            return model;
        }

        public FileContentResult GetImage(string name)
        {
            var chapter = _chapterService.GetChapter(name);
            return chapter.ImageMimeType != null ? File(chapter.ImageData, chapter.ImageMimeType) : null;
        }
    }
}