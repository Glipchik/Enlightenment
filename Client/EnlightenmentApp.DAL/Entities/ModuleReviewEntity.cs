using EnlightenmentApp.DAL.Interfaces.Entities;

namespace EnlightenmentApp.DAL.Entities
{
    public class ModuleReviewEntity : IEntity
    {
        #nullable disable
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public ModuleEntity Module { get; set; }
        public int ModuleId {  get; set; }
    }
}
