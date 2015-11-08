using System.ComponentModel.DataAnnotations;

namespace MusicArtists.Models
{
    public class Song 
    {
        public int SongId { get; set; }

        [Required]
        [MaxLength(25)]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int ArtistId { get; set; }

        [Required]
        public virtual Artist Artist { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
