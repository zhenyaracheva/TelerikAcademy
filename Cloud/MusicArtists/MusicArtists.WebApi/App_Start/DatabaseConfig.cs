namespace MusicArtists.WebApi
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicArtistsDbContext, Configuration>());
            MusicArtistsDbContext.Create().Database.Initialize(true);
        }
    }
}