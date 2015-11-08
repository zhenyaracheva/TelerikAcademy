namespace MusicArtists.WebApi.Controllers
{
    using Data;
    using MusicArtists.Models;
    using Models;
    using System.Linq;
    using System.Web.Http;
    using Data.Contracts;

    public class CountriesController : ApiController
    {
        private IRepository<Country> countries;

        public CountriesController()
        {
            this.countries = new Repository<Country>(new MusicArtistsDbContext());
        }

        public IHttpActionResult Get()
        {
            var result = this.countries
                         .All()
                         .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var country = this.countries
                             .GetById(id);

            return this.Ok(string.Format("Country: {0}", country.Name));
        }

        public IHttpActionResult Post(CountryModel country)
        {
            this.countries
                 .Add(new Country
                 {
                     Name = country.Name
                 });

            var countryId = this.countries.SaveChanges();

            return this.Ok(string.Format("Added {0} country: {1}", countryId, country.Name));
        }

        public IHttpActionResult Delete(int id)
        {
            this.countries.Delete(id);
            this.countries.SaveChanges();

            return this.Ok(string.Format("Deleted country: {0}", id));
        }
    }
}
