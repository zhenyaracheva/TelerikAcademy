namespace MusicArtists.Data.Contracts
{
    using MusicArtists.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IMusicArtistsDbContext
    {
        IDbSet<Artist> Artist { get; set; }


        IDbSet<Song> Songs { get; set; }


        IDbSet<Country> Countries { get; set; }


        IDbSet<Producer> Producers { get; set; }


        IDbSet<Album> Albums { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
