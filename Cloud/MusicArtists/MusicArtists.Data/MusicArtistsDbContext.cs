namespace MusicArtists.Data
{
    using Models;
    using Contracts;
    using System.Data.Entity;

    public class MusicArtistsDbContext : DbContext, IMusicArtistsDbContext
    {
        public MusicArtistsDbContext()
            : base("MusucArtists")
        {
        }

        public virtual IDbSet<Artist> Artist { get; set; }


        public virtual IDbSet<Song> Songs { get; set; }


        public virtual IDbSet<Country> Countries { get; set; }


        public virtual IDbSet<Producer> Producers { get; set; }


        public virtual IDbSet<Album> Albums { get; set; }

        public static MusicArtistsDbContext Create()
        {
            return new MusicArtistsDbContext();
        }
    }
}
