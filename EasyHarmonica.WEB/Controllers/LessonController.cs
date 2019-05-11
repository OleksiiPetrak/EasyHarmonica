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
        private readonly IUserService _userService;
        private readonly IAchievementService _achievementService;
        private readonly IChapterService _chapterService;
        
        public LessonController(ILessonService lessonService, IUserService userService,
            IAchievementService achievementService, IChapterService chapterService)
        {
            _lessonService = lessonService;
            _userService = userService;
            _achievementService = achievementService;
            _chapterService = chapterService;
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

            var lesson = Mapper.Map<LessonDTO, CreateLessonModel>(lessonDto);

            var usersEmails = new List<string>();
            var achievementsNames = new List<string>();

            foreach (var user in lessonDto.Users)
            {
                usersEmails.Add(user.Email);
            }

            lesson.UsersEmails = usersEmails;

            foreach (var achievement in lessonDto.Achievements)
            {
                achievementsNames.Add(achievement.Name);
            }

            lesson.AchievementsNames = achievementsNames;

            var result = InitializeCreateLessonModel(lesson);

            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> EditLesson(CreateLessonModel lesson, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    lesson.ImageMimeType = image.ContentType;
                    lesson.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(lesson.ImageData, 0, image.ContentLength);
                }

                var lessonDto = Mapper.Map<CreateLessonModel, LessonDTO>(lesson);
                await _lessonService.EditLesson(lessonDto).ConfigureAwait(false);

                return RedirectToAction("GetChapters", "Chapter");
            }

            return View(lesson);
        }

        private CreateLessonModel InitializeCreateLessonModel(CreateLessonModel model)
        {
            var userDtos = _userService.GetAllUsers();
            var achievementDtos = _achievementService.GetAllAchievements();
            var chaptersDtos = _chapterService.GetAllChapters();
            
            model.Users = new MultiSelectList(userDtos, "Email", "Email");
            model.Achievements = new MultiSelectList(achievementDtos, "Name", "Name");
            model.Chapter = new SelectList(chaptersDtos, "Name", "Name");

            return model;
        }

        public FileContentResult GetImage(string name)
        {
            var lesson = _lessonService.GetLesson(name);
            return lesson.ImageMimeType != null ? File(lesson.ImageData, lesson.ImageMimeType) : null;
        }
    }
}