namespace EnlightenmentApp.DAL.Entities
{
    public class SectionEntity : BaseEntity
    {
        #nullable disable
        public string Name { get; set; }
        public ICollection<ChapterEntity> Chapters { get; set; }
        public int ModuleId { get; set; }
        public ModuleEntity Module { get; set; }
    }
}
