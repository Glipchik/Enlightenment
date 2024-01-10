namespace EnlightenmentApp.DAL.Entities
{
    public class PathEntity : BaseEntity
    {
        #nullable disable
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Cost { get; set; }
        public ICollection<TagEntity> Tags { get; set; }
        public ICollection<ModuleEntity> Modules { get; set; }
    }
}
