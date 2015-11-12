namespace MusicArtists.WebApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Models;
    using MusicArtists.Models;
    using Data.Contracts;

    public class SongsController : ApiController
    {
        private IRepository<Song> songs;
        private IRepository<Country> countries;
        private IRepository<Artist> artists;
        private IRepository<Album> albums;

        public SongsController()
        {
            var db = new MusicArtistsDbContext();
            this.songs = new Repository<Song>(db);
            this.countries = new Repository<Country>(db);
            this.artists = new Repository<Artist>(db);
            this.albums = new Repository<Album>(db);
        }

        public IHttpActionResult Get()
        {
            var songs = this.songs
                         .All()
                         .ToList();

            return this.Ok(songs);
        }

        public IHttpActionResult Get(int id)
        {
            var songs = this.songs
                             .GetById(id);

            return this.Ok(songs);
        }

        public IHttpActionResult Post(SongModel songmodel)
        {
            Artist artist = null;

            if (songmodel.Artist != null)
            {
                artist = this.artists
                                .All()
                                .Where(x => x.Name == songmodel.Artist.Name)
                                .FirstOrDefault();

                if (artist == null)
                {

                    var country = this.countries
                                      .All().Where(x => x.Name == songmodel.Artist.Country.Name)
                                      .FirstOrDefault();

                    if (country == null)
                    {
                        country = new Country { Name = songmodel.Artist.Country.Name };
                        this.countries.Add(country);
                        this.countries.SaveChanges();
                    }

                    artist = new Artist
                    {
                        Name = songmodel.Artist.Name,
                        DateOfBirth = songmodel.Artist.DateOfBirth,
                        Country = country
                    };

                    this.artists.Add(artist);
                    this.artists.SaveChanges();
                }
            }

            var song = new Song
            {
                Title = songmodel.Title,
                Genre = songmodel.Genre,
                Year = songmodel.Year,
                ArtistId = artist.ArtistId,
                Album = this.albums.All().FirstOrDefault()
            };

            this.songs.Add(song);
            
            var songtId = this.songs.SaveChanges();

            return this.Ok("Yesss!");
        }

        public IHttpActionResult Delete(int id)
        {
            this.songs.Delete(id);
            this.songs.SaveChanges();

            return this.Ok(string.Format("Deleted song: {0}", id));
        }
    }
}
