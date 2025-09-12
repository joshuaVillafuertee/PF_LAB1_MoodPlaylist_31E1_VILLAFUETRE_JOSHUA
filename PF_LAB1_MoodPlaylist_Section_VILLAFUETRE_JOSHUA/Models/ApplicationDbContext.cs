using Microsoft.EntityFrameworkCore;
using PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Models;
using PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Repository.Models;

namespace PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Playlist> Playlists { get; set; } = null!;
        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<MoodTag> MoodTags { get; set; } = null!;
    }
}
