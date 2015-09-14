namespace CompositePattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SongGroup : SongComponent
    {
        private List<SongComponent> songGoups = new List<SongComponent>();

        public SongGroup(string style)
        {
            this.Style = style;
        }

        public string Style { get; set; }

        public void Add(SongComponent songComponet)
        {
            if (songComponet != null)
            {
                this.songGoups.Add(songComponet);
            }
        }

        public void Remove(SongComponent songComponent)
        {
            if (this.songGoups != null && this.songGoups.Contains(songComponent))
            {
                this.songGoups.Remove(songComponent);
            }
        }

        public override void DisplayInfo(int depth)
        {
            Console.WriteLine(new string('-', depth) + this.Style);

            foreach (var group in this.songGoups)
            {
                group.DisplayInfo(depth + 2);
            }
        }
    }
}
