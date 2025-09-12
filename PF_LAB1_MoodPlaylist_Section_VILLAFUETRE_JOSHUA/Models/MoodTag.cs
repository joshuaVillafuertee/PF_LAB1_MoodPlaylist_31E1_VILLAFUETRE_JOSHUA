using System.ComponentModel.DataAnnotations;

namespace PF_LAB1_MoodPlaylist_Section_VILLAFUETRE_JOSHUA.Repository.Models
{
    public class MoodTag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
