namespace EnlightenmentApp.API.Models.ModuleReview
{
    public class ModuleReviewViewModel : BaseModel
    {
        #nullable disable
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public int ModuleId { get; set; }
    }
}
