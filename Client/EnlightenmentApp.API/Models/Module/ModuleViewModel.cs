using EnlightenmentApp.API.Models.ModuleReview;
using EnlightenmentApp.API.Models.Section;
using EnlightenmentApp.API.Models.Tag;

namespace EnlightenmentApp.API.Models.Module
{
    public class ModuleViewModel
    {
        #nullable disable
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public float Rating { get; set; }
        public int Cost { get; set; }
        public string Summary { get; set; }
        public ICollection<ModuleReviewViewModel> Reviews { get; set; }
        public ICollection<TagViewModel> Tags { get; set; }
        public string ImageSrc { get; set; }
        public ICollection<SectionViewModel> Sections { get; set; }
        public bool IsCompleted { get; set; }
    }
}
