namespace EnlightenmentApp.BLL.Entities
{
    public class Chapter : BaseItem
    {
        #nullable disable
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
        public string CheatSheet { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}
