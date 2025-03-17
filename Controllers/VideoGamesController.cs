using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGame.Entities;

namespace VideoGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly VideoGameRepository _repository;

        public VideoGamesController(VideoGameRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGameEntity>>> GetGames() => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGameEntity>> GetGame(int id)
        {
            var game = await _repository.GetByIdAsync(id);
            return game == null ? NotFound() : Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGameEntity>> CreateGame(VideoGameEntity game)
        {
            await _repository.AddAsync(game);
            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, VideoGameEntity game)
        {

            Console.WriteLine($"Received ID from URL: {id}");
            Console.WriteLine($"Received ID from Body: {game.Id}");

            if (id != game.Id) return BadRequest();
            await _repository.UpdateAsync(game);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
