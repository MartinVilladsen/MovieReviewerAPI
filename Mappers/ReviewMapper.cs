using imdbRanking.DTO;
using imdbRanking.Models;

namespace imdbRanking.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDTO ToReviewDTO(this Review review)
        {
            return new ReviewDTO
            {
                Id = review.Id,
                Reviewer = review.Reviewer,
                Content = review.Content,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt,
                MovieId = review.MovieId
            };
        }

        public static Review CreateReviewRequest(this CreateReviewRequest dto, int movieId)
        {
            return new Review
            {
                Reviewer = dto.Reviewer,
                Content = dto.Content,
                Rating = dto.Rating,
                CreatedAt = DateTime.Now,
                MovieId = movieId
            };
        }
    }
}
