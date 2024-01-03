using EnlightenmentApp.DAL.Entities;

namespace EnlightenmentApp.BLL.Entities
{
    public class Section : BaseItem
    {
        #nullable disable
        public string Name { get; set; }
        public ICollection<Chapter> Chapters { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
