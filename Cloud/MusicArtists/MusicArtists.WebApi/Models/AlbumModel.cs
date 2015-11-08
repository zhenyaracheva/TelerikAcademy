using MusicArtists.Models;
using System.Collections.Generic;

namespace MusicArtists.WebApi.Models
{
    public class AlbumModel
    {
        public string Title { get; set; }


        public int Year { get; set; }


        public Producer Producer { get; set; }

        public ICollection<Artist> Artists { get; set; }
    }
}