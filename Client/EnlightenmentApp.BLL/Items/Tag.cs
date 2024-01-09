using EnlightenmentApp.Shared.Enums;

namespace EnlightenmentApp.BLL.Entities
{
    public class Tag : BaseItem
    {
        #nullable disable
        public TagType Type { get; set; }
        public string Value { get; set; }
        public string MetaData { get; set; }
        public bool IsBasic { get; set; }
        public ICollection<Module> Modules { get; set; }
        public ICollection<Path> Paths { get; set; }
    }
}
