namespace EnlightenmentApp.BLL.Entities
{
    public class Module : BaseItem
    {
        #nullable disable
        public string Title { get; set; }
        public string Author { get; set; }
        public float Rating { get; set; }
        public int Cost { get; set; }
        public string Summary { get; set; }
        public ICollection<ModuleReview> Reviews { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public string ImageSrc { get; set; }
        public ICollection<Path> Paths { get; set; }
        public ICollection<Section> Sections { get; set; }
        public bool IsCompleted { get; set; }
    }
}
