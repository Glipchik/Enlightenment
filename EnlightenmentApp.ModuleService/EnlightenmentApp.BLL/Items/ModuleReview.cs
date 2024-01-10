namespace EnlightenmentApp.BLL.Entities
{
    public class ModuleReview : BaseItem
    {
        #nullable disable
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public Module Module { get; set; }
        public int ModuleId { get; set; }
    }
}
