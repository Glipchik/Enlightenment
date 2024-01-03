using EnlightenmentApp.DAL.Enums;
using EnlightenmentApp.DAL.Interfaces.Entities;

namespace EnlightenmentApp.DAL.Entities
{
    public class TagEntity : IEntity
    {
        #nullable disable
        public int Id { get; set; }
        public TagType Type { get; set; }
        public string Value { get; set; }
        public string MetaData { get; set; }
        public bool IsBasic { get; set; }
        public ICollection<ModuleEntity> Modules { get; }
        public ICollection<PathEntity> Paths { get; }
    }
}
