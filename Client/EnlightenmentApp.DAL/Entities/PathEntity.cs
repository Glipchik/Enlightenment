using EnlightenmentApp.DAL.Interfaces.Entities;

namespace EnlightenmentApp.DAL.Entities
{
    public class PathEntity : IEntity
    {
        #nullable disable
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Cost { get; set; }
        public ICollection<TagEntity> Tags { get; set; }
        public ICollection<ModuleEntity> Modules { get; set; }
    }
}
