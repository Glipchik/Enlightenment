namespace EnlightenmentApp.BLL.Entities
{
    public class Path : BaseItem
    {
        #nullable disable
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Cost { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Module> Modules { get; set; }
    }
}
