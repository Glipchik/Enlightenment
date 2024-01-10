namespace EnlightenmentApp.API.Models.ModuleReview
{
    public class ModuleReviewViewModel
    {
        #nullable disable
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public int ModuleId { get; set; }
    }
}
