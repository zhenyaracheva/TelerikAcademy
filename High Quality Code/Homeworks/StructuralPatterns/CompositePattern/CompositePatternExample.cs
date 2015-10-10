namespace CompositePattern
{
    public class CompositePatternExample
    {
        public static void Main(string[] args)
        {
            var group = new SongGroup("Group 1");
            var song1 = new Song("Artist1", "Title1");
            var song2 = new Song("Artist2", "Title2");
            group.Add(song1);
            group.Add(song2);

            var group2 = new SongGroup("Group 2");
            var song3 = new Song("Artist3", "Title3");
            var song4 = new Song("Artist4", "Title4");
            group2.Add(song3);
            group2.Add(song4);

            group.Add(group2);
            group.DisplayInfo(0);
        }
    }
}
