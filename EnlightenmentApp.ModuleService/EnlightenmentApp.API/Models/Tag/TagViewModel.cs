using EnlightenmentApp.Shared.Enums;

namespace EnlightenmentApp.API.Models.Tag
{
    public class TagViewModel
    {
        #nullable disable
        public int Id { get; set; }
        public TagType Type { get; set; }
        public string Value { get; set; }
        public string MetaData { get; set; }
        public bool IsBasic { get; set; }
    }
}
