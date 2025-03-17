using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VideoGame.DatabaseContext;

using VideoGame.Entities;

namespace VideoGame
{
    public class VideoGameRepositoryTests
    {
        private readonly VideoGameRepository _repository;
        private readonly VideoGameDatabaseContext _context;

        public VideoGameRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<VideoGameDatabaseContext>()
                .UseInMemoryDatabase(databaseName: "VideoGame")
                .Options;

            _context = new VideoGameDatabaseContext(options);
            _repository = new VideoGameRepository(_context);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsEmptyList_WhenNoGamesExist()
        {
            var games = await _repository.GetAllAsync();
            Assert.Empty(games);
        }

        [Fact]
        public async Task AddAsync_AddsGameToDatabase()
        {
            var game = new VideoGameEntity { Title = "Test Game", Genre = "Action", ReleaseYear = 2022 };
            await _repository.AddAsync(game);
            Assert.Single(await _repository.GetAllAsync());
        }
    }
}
