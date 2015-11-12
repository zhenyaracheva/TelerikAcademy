namespace MusicArtists.WebApi.Controllers
{
    using Data.Contracts;
    using MusicArtists.Models;
    using System.Web.Http;
    using System.Linq;
    using Models;

    public class AlbumsController : ApiController
    {
        private IRepository<Producer> producers;
        private IRepository<Album> albums;

        public AlbumsController(IRepository<Producer> producersRepo, IRepository<Album> albumsRepo)
        {
            this.producers = producersRepo;
            this.albums = albumsRepo;
        }

        public IHttpActionResult Get()
        {
            var artists = this.albums
                         .All()
                         .ToList();

            return this.Ok(artists);
        }

        public IHttpActionResult Get(int id)
        {
            var artist = this.albums
                             .GetById(id);

            return this.Ok(artist);
        }

        public IHttpActionResult Post(AlbumModel albumModel)
        {
            var producer = this.producers
                                .All()
                                .Where(x => x.Name == albumModel.Producer.Name)
                                .FirstOrDefault();

            if (producer == null)
            {
                producer = new Producer { Name = albumModel.Producer.Name };
                this.producers.Add(producer);
                this.producers.SaveChanges();
            }


            this.albums.Add(new Album
            {
                Title = albumModel.Title,
                Year = albumModel.Year,
                ProducerId = producer.ProducerId,
                Artists = albumModel.Artists
            });

            var albumId = this.albums.SaveChanges();
            return this.Ok(string.Format("Added {0} artist: {1}", albumId, albumModel.Title));
        }

        public IHttpActionResult Delete(int id)
        {
            this.albums.Delete(id);
            this.albums.SaveChanges();

            return this.Ok(string.Format("Deleted artist: {0}", id));
        }
    }
}
