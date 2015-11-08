namespace MusicArtists.WebApi.Models
{
    using MusicArtists.Models;
    using System;
    using System.Collections.Generic;

    public class ArtistsModel
    {
        public string Name { get; set; }


        public DateTime DateOfBirth { get; set; }


        public CountryModel Country { get; set; }


        public ICollection<Album> Albums { get; set; }
    }
}