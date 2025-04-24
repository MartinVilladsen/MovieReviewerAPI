using imdbRanking.Models;

namespace imdbRanking.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int ImdbNumber { get; set; }
        public List<ReviewDTO> Reviews { get; set; } = new List<ReviewDTO>();
    }
}
