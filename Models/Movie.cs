namespace imdbRanking.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string ?Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int ImdbNumber { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
