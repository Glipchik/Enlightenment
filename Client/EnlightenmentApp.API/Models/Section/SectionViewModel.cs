using EnlightenmentApp.API.Models.Chapter;

namespace EnlightenmentApp.API.Models.Section
{
    public class SectionViewModel : BaseModel
    {
        #nullable disable
        public string Name { get; set; }
        public ICollection<ChapterViewModel> Chapters { get; set; }
        public int ModuleId { get; set; }
    }
}
