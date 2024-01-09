using EnlightenmentApp.Shared.Enums;

namespace EnlightenmentApp.DAL.Entities
{
    public class TagEntity : BaseEntity
    {
        #nullable disable
        public TagType Type { get; set; }
        public string Value { get; set; }
        public string MetaData { get; set; }
        public bool IsBasic { get; set; }
        public ICollection<ModuleEntity> Modules { get; set; }
        public ICollection<PathEntity> Paths { get; set; }
    }
}
