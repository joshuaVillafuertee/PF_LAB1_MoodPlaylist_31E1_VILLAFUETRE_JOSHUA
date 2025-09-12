using Microsoft.EntityFrameworkCore;
using PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Models;
using PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Repository.Data;
using PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Repository.Models;

namespace PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Services
{
    public class PlaylistService
    {
        private readonly ApplicationDbContext _context;

        public PlaylistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreatePlaylist(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            _context.SaveChanges();
        }

        public List<Playlist> GetAllPlaylists()
        {
            return _context.Playlists
                .Include(p => p.Songs)
                .ToList();
        }

        public Playlist? GetPlaylistById(int id)
        {
            return _context.Playlists
                .Include(p => p.Songs)
                .FirstOrDefault(p => p.Id == id);
        }

        public void DeletePlaylist(int id)
        {
            var playlist = _context.Playlists
                .Include(p => p.Songs)
                .FirstOrDefault(p => p.Id == id);

            if (playlist != null)
            {
                // Remove all songs in the playlist first
                _context.Songs.RemoveRange(playlist.Songs);

                _context.Playlists.Remove(playlist);
                _context.SaveChanges();
            }
        }
    }
}
