namespace EnlightenmentApp.API.Models.Chapter
{
    public class ChapterViewModel : BaseModel
    {
        #nullable disable
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; } 
        public string CheatSheet { get; set; }
        public int SectionId { get; set; }
    }
}
