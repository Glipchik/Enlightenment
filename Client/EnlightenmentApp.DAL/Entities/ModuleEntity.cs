using EnlightenmentApp.DAL.Interfaces.Entities;

namespace EnlightenmentApp.DAL.Entities
{
    public class ModuleEntity : IEntity
    {
        #nullable disable
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public float Rating { get; set; }
        public int Cost { get; set; }
        public string Summary { get; set; }
        public ICollection<ModuleReviewEntity> Reviews { get; set; }
        public ICollection<TagEntity> Tags { get; set; }
        public string ImageSrc { get; set; }
        public ICollection<PathEntity> Paths { get; }
        public ICollection<SectionEntity> Sections { get; set; }
        public bool IsCompleted { get; set; }
    }
}
