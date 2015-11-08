namespace MusicArtists.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album 
    {
        private ICollection<Song> songs;
        private ICollection<Artist> artists;

        public Album()
        {
            this.songs = new HashSet<Song>();
            this.artists = new HashSet<Artist>();
        }

        public int AlbumId { get; set; }

        [Required]
        [MaxLength(25)]
        public string Title { get; set; }


        public int Year { get; set; }


        public int ProducerId { get; set; }

        [Required]
        public virtual Producer Producer { get; set; }


        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
        }
    }
}
