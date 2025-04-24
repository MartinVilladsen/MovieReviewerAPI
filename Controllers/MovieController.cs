using imdbRanking.Data;
using imdbRanking.DTO;
using imdbRanking.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace imdbRanking.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly DbContextApplication _context;
        public MovieController(DbContextApplication context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var moviesFromDb = await _context.Movies
                                .Include(m => m.Reviews)
                                .ToListAsync();

            var movieDtos = moviesFromDb.Select(m => m.ToMovieDTO()).ToList();

            return Ok(movieDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById([FromRoute] int id)
        {
            var movie = await _context.Movies
           .Include(m => m.Reviews)
           .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie.ToMovieDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieRequest movieDTO)
        {
            var movie = movieDTO.CreateMovieRequest();
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie.ToMovieDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMovieRequest movieDTO)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            movie.Title = movieDTO.Title;
            movie.ImdbNumber = movieDTO.ImdbNumber;
            movie.ReleaseYear = movieDTO.ReleaseYear;

            await _context.SaveChangesAsync();

            return Ok(movie.ToMovieDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }

    }
}
