namespace EnlightenmentApp.API.Models.Section
{
    public class SectionViewModel
    {
        #nullable disable
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
        public string CheatSheet { get; set; }
        public int ModuleId { get; set; }
    }
}
