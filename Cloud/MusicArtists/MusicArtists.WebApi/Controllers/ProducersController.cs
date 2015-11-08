namespace MusicArtists.WebApi.Controllers
{
    using Data;
    using Models;
    using Data.Contracts;
    using MusicArtists.Models;
    using System.Linq;
    using System.Web.Http;

    public class ProducersController : ApiController
    {
        //private IMusicArtistsData data;
        private IRepository<Producer> producers;

        public ProducersController()
        {
            this.producers = new Repository<Producer>(new MusicArtistsDbContext());

        }


        public IHttpActionResult Get()
        {
            var producers = this.producers
                         .All()
                         .ToList();

            return this.Ok(producers);
        }

        public IHttpActionResult Get(int id)
        {
            var producer = this.producers
                             .GetById(id);

            return this.Ok(string.Format("Producer: {0}", producer.Name));
        }

        public IHttpActionResult Post(ProducerModel producer)
        {
            this.producers.Add(new Producer
            {
                Name = producer.Name
            });

            var producerId = this.producers.SaveChanges();

            return this.Ok(string.Format("Added {0} country: {1}", producerId, producer.Name));
        }

        public IHttpActionResult Delete(int id)
        {
            this.producers.Delete(id);
            this.producers.SaveChanges();

            return this.Ok(string.Format("Deleted producer: {0}", id));
        }
    }
}
