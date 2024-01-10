namespace EnlightenmentApp.DAL.Entities
{
    public class SectionEntity : BaseEntity
    {
        #nullable disable
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
        public string CheatSheet { get; set; }
        public int ModuleId { get; set; }
        public ModuleEntity Module { get; set; }
    }
}
