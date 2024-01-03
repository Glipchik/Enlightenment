namespace EnlightenmentApp.DAL.Entities
{
    public class ModuleReviewEntity : BaseEntity
    {
        #nullable disable
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public ModuleEntity Module { get; set; }
        public int ModuleId {  get; set; }
    }
}
