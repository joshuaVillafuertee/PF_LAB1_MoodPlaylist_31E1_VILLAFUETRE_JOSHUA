using Microsoft.EntityFrameworkCore;
using PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Models;
using PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Repository.Data;
using PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Repository.Models;

namespace PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Services
{
    public class SongService
    {
        private readonly ApplicationDbContext _context;

        public SongService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddSong(Song song)
        {
            _context.Songs.Add(song);
            _context.SaveChanges();
        }

        public List<Song> GetAllSongs()
        {
            return _context.Songs
                .Include(s => s.Playlist)
                .ToList();
        }

        public Song? GetSongById(int id)
        {
            return _context.Songs
                .Include(s => s.Playlist)
                .FirstOrDefault(s => s.Id == id);
        }

        public void UpdateSong(Song song)
        {
            _context.Songs.Update(song);
            _context.SaveChanges();
        }

        public void DeleteSong(int id)
        {
            var song = _context.Songs.Find(id);
            if (song != null)
            {
                _context.Songs.Remove(song);
                _context.SaveChanges();
            }
        }
    }
}
