namespace CompositePattern
{
    using System;

    public class Song : SongComponent
    {
        public Song(string artist, string title)
        {
            this.Artist = artist;
            this.Title = title;
        }

        public string Artist { get; set; }

        public string Title { get; set; }

        public override void DisplayInfo(int depth)
        {
            Console.WriteLine(new string('-', depth) + "Artist: " + this.Artist + ", Title: " + this.Title);
        }
    }
}
