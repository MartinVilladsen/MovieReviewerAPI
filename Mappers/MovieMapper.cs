using imdbRanking.DTO;
using imdbRanking.Models;
using System.Runtime.CompilerServices;

namespace imdbRanking.Mappers
{
    public static class MovieMapper
    {
        public static MovieDTO ToMovieDTO(this Movie movieModel)
        {
            return new MovieDTO
            {
                Id = movieModel.Id,
                Title = movieModel.Title,
                ReleaseYear = movieModel.ReleaseYear,
                ImdbNumber = movieModel.ImdbNumber,
                Reviews = movieModel.Reviews 
                           .Select(review => review.ToReviewDTO()) 
                           .ToList()
            };
        }

        public static Movie CreateMovieRequest(this CreateMovieRequest movie)
        {
            return new Movie
            {
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                ImdbNumber = movie.ImdbNumber
            };
        }
    }
}
