namespace MusicArtists.WebApi.Models
{
    using MusicArtists.Models;


    public class SongModel
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public ArtistsModel Artist { get; set; }

        public  AlbumModel Album { get; set; }
    }
}