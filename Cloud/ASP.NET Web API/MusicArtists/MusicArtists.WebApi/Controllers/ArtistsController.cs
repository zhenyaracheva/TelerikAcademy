namespace MusicArtists.WebApi.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Models;
    using MusicArtists.Models;
    using Data.Contracts;

    public class ArtistsController : ApiController
    {
        private IRepository<Artist> artists;
        private IRepository<Country> countries;

        public ArtistsController(IRepository<Artist> artists, IRepository<Country> countries)
        {
            this.artists = artists;
            this.countries = countries;

        }

        public IHttpActionResult Get()
        {
            var artists = this.artists
                         .All()
                         .ToList();

            return this.Ok(artists);
        }

        public IHttpActionResult Get(int id)
        {
            var artist = this.artists
                             .GetById(id);

            return this.Ok(artist);
        }

        public IHttpActionResult Post(ArtistsModel artistModel)
        {
            if (this.artists.All().Any(x => x.Name == artistModel.Name))
            {
                return this.BadRequest("Aleady added artist!");
            }

            var country = this.countries
                                .All()
                                .Where(x => x.Name == artistModel.Country.Name)
                                .FirstOrDefault();

            if (country == null)
            {
                this.countries.Add(new Country { Name = artistModel.Country.Name });
                this.countries.SaveChanges();
            }

            var artist = new Artist
            {
                Name = artistModel.Name,
                DateOfBirth = artistModel.DateOfBirth,
                CountryId = country.CountryId
            };

            this.artists.Add(artist);

            var artistId = this.artists.SaveChanges();
            return this.Ok(string.Format("Added {0} artist: {1}", artistId, artist.Name));
        }

        public IHttpActionResult Delete(int id)
        {
            this.artists.Delete(id);
            this.artists.SaveChanges();

            return this.Ok(string.Format("Deleted artist: {0}", id));
        }
    }
}
