using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using EasyHarmonica.BLL.Interfaces;
using System.Web.Mvc;
using AutoMapper;
using EasyHarmonica.BLL.DTO;
using EasyHarmonica.WEB.Models;

namespace EasyHarmonica.WEB.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public ActionResult GetLessons()
        {        
             var lessonsDto = _lessonService.GetAllLessons();
             var results = Mapper.Map<IEnumerable<LessonDTO>, IEnumerable<LessonModel>>(lessonsDto);
             var startModel = new StartViewModel() {Lessons = results};

             return PartialView(startModel);   
        }

        [HttpGet]
        public ViewResult EditLesson(string name)
        {
            var lessonDto = _lessonService.GetLesson(name);

            var lesson = Mapper.Map<LessonDTO, LessonModel>(lessonDto);

            return View(lesson);
        }

        [HttpPost]
        public async Task<ActionResult> EditLesson(LessonModel lesson, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    lesson.ImageMimeType = image.ContentType;
                    lesson.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(lesson.ImageData, 0, image.ContentLength);
                }

                var lessonDto = Mapper.Map<LessonModel, LessonDTO>(lesson);
                await _lessonService.EditLesson(lessonDto).ConfigureAwait(false);

                return RedirectToAction("GetChapters", "Chapter");
            }

            return View(lesson);
        }

        public FileContentResult GetImage(string name)
        {
            var lesson = _lessonService.GetLesson(name);
            return lesson.ImageMimeType != null ? File(lesson.ImageData, lesson.ImageMimeType) : null;
        }
    }
}