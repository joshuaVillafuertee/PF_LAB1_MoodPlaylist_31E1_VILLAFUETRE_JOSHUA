using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(250)]
        public string Description { get; set; } = string.Empty;

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
