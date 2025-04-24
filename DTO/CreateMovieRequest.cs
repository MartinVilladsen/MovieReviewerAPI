namespace imdbRanking.DTO
{
    public class CreateMovieRequest
    {
        public string? Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int ImdbNumber { get; set; }
    }
}
