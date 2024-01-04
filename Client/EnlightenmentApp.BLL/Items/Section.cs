namespace EnlightenmentApp.BLL.Entities
{
    public class Section : BaseItem
    {
        #nullable disable
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
        public string CheatSheet { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
