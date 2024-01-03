using EnlightenmentApp.API.Enums;

namespace EnlightenmentApp.API.Models.Tag
{
    public class TagViewModel : BaseModel
    {
        #nullable disable
        public TagType Type { get; set; }
        public string Value { get; set; }
        public string MetaData { get; set; }
        public bool IsBasic { get; set; }
    }
}
