using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string Mood { get; set; } = string.Empty;
        public string YouTubeUrl { get; set; } = string.Empty;

        // ✅ New: Album Cover / Image URL
        public string ImageUrl { get; set; } = string.Empty;

        public int? PlaylistId { get; set; }

        [ForeignKey("PlaylistId")]
        public Playlist? Playlist { get; set; }

        public string? VideoId
        {
            get
            {
                var match = Regex.Match(YouTubeUrl, @"(?:v=|youtu\.be/)([a-zA-Z0-9_-]+)");
                return match.Success ? match.Groups[1].Value : null;
            }
        }

        public string ThumbnailUrl => VideoId != null
            ? $"https://img.youtube.com/vi/{VideoId}/hqdefault.jpg"
            : "/images/default-thumbnail.jpg";
    }
}
