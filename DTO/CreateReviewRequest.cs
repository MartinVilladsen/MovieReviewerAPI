namespace imdbRanking.DTO
{
    public class CreateReviewRequest
    {
        public string? Reviewer { get; set; }
        public string? Content { get; set; }
        public decimal Rating { get; set; }
    }
}
