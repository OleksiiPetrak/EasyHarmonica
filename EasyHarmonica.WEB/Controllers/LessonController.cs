using System.Collections.Generic;
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
    }
}