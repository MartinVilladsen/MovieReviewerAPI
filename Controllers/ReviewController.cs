using imdbRanking.Data;
using imdbRanking.DTO;
using imdbRanking.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace imdbRanking.Controllers
{
    [Route("api/movies/{movieId}/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly DbContextApplication _context;

        public ReviewController(DbContextApplication context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int movieId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.MovieId == movieId)
                .Select(r => r.ToReviewDTO())
                .ToListAsync();

            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int movieId, [FromBody] CreateReviewRequest dto)
        {
            var movieExists = await _context.Movies.AnyAsync(m => m.Id == movieId);
            if (!movieExists) return NotFound("Movie not found");

            var review = dto.CreateReviewRequest(movieId);

            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { movieId = movieId }, review.ToReviewDTO());
        }

        [HttpPut("{reviewId}")]
        public async Task<IActionResult> Update(int movieId, int reviewId, [FromBody] UpdateReviewRequest dto)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId && r.MovieId == movieId);
            if (review == null) return NotFound();

            review.Content = dto.Content ?? review.Content;
            review.Rating = dto.Rating;

            await _context.SaveChangesAsync();
            return Ok(review.ToReviewDTO());
        }

        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> Delete(int movieId, int reviewId)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId && r.MovieId == movieId);
            if (review == null) return NotFound();

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
