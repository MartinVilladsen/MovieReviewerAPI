namespace imdbRanking.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ?Reviewer { get; set; }
        public string ?Content { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MovieId { get; set; }
        public Movie ?Movie { get; set; }
    }
}
