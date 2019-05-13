using EasyHarmonica.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyHarmonica.BLL.Interfaces
{
    public interface ILessonService
    {
        Task CreateLesson(LessonDTO lessonDto);
        IEnumerable<LessonDTO> GetAllLessons();
        LessonDTO GetLesson(string lessonName);
        string GetNextLessonName(int id);
        Task EditLesson(LessonDTO lessonDto);
        Task DeleteLesson(int id);
    }
}
