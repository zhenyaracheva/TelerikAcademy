namespace MusicArtists.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Artist 
    {
        private ICollection<Album> albums;


        public Artist()
        {
            this.albums = new HashSet<Album>();
        }

        public int ArtistId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public string Name { get; set; }


        public DateTime? DateOfBirth { get; set; }


        public int CountryId { get; set; }

        [Required]
        public virtual Country Country { get; set; }


        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
