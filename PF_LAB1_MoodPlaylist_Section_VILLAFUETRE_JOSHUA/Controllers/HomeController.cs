using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Models;
using PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Repository.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        
        public async Task<IActionResult> Index()
        {
            try
            {
                var songs = await _context.Songs
                    .Include(s => s.Playlist)
                    .ToListAsync();

                return View(songs); 
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error loading songs in Home/Index");
                return View(Enumerable.Empty<Song>()); 
            }
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
