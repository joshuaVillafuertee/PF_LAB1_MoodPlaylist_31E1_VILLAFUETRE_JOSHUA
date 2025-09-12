using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Models;
using PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Repository.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Controllers
{
    public class SongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var songs = _context.Songs.Include(s => s.Playlist);
            return View(await songs.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Songs.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Name", song.PlaylistId);
            return View(song);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var song = await _context.Songs.FindAsync(id);
            if (song == null) return NotFound();

            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Name", song.PlaylistId);
            return View(song);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Song song)
        {
            if (id != song.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Songs.Any(e => e.Id == song.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Name", song.PlaylistId);
            return View(song);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var song = await _context.Songs
                .Include(s => s.Playlist)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (song == null) return NotFound();

            return View(song);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var song = await _context.Songs
                .Include(s => s.Playlist)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (song == null) return NotFound();

            return View(song);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song != null)
            {
                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
