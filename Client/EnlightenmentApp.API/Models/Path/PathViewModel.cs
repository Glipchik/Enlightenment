using EnlightenmentApp.API.Models.Module;
using EnlightenmentApp.API.Models.Tag;

namespace EnlightenmentApp.API.Models.Path
{
    public class PathViewModel : BaseModel
    {
        #nullable disable
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Cost { get; set; }
        public ICollection<TagViewModel> Tags { get; set; }
        public ICollection<ModuleViewModel> Modules { get; set; }
    }
}
