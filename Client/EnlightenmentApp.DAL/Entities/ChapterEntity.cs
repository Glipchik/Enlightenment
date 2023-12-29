namespace EnlightenmentApp.DAL.Entities
{
    public class ChapterEntity
    {
        #nullable disable
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsCompleted {  get; set; }
        public string CheatSheet { get; set; }
        public int SectionId { get; set; }
        public SectionEntity Section { get; set; }
    }
}
