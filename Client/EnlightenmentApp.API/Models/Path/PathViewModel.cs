using EnlightenmentApp.API.Models.Module;
using EnlightenmentApp.API.Models.Tag;

namespace EnlightenmentApp.API.Models.Path
{
    public class PathViewModel
    {
        #nullable disable
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Cost { get; set; }
        public ICollection<TagViewModel> Tags { get; set; }
        public ICollection<ModuleViewModel> Modules { get; set; }
    }
}
