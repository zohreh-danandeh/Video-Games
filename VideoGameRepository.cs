using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGame.DatabaseContext;
using VideoGame.Entities;

namespace VideoGame
{
    public class VideoGameRepository
    {
        private readonly VideoGameDatabaseContext _context;

        public VideoGameRepository(VideoGameDatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<VideoGameEntity>> GetAllAsync() => await _context.VideoGames.ToListAsync();

        public async Task<VideoGameEntity?> GetByIdAsync(int id) => await _context.VideoGames.FindAsync(id);

        public async Task AddAsync(VideoGameEntity game)
        {
            _context.VideoGames.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VideoGameEntity game)
        {
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game != null)
            {
                _context.VideoGames.Remove(game);
                await _context.SaveChangesAsync();
            }
        }
    }
}
