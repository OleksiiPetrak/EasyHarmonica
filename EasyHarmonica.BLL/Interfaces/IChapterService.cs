using EasyHarmonica.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyHarmonica.BLL.Interfaces
{
    public interface IChapterService
    {
        Task CreateChapter(ChapterDTO chapterDto);
        IEnumerable<ChapterDTO> GetAllChapters();
        ChapterDTO GetChapter(string chapterName);
        Task EditChapter(ChapterDTO chapterDto);
        Task DeleteChapter(int id);
    }
}
