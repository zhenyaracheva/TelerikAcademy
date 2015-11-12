namespace MusicArtists.Data
{
    using MusicArtists.Data.Contracts;
    using MusicArtists.Models;

    public interface IMusicArtistsData
    {
        IRepository<Artist> Artists { get; }

        IRepository<Album> Albums { get; }

        IRepository<Song> Songs { get; }

        IRepository<Country> Countries { get; }

        IRepository<Producer> Producers { get; }

        int SaveChanges();
    }
}
