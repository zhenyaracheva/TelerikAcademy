namespace ComputersLogic.VideoCardTypes
{
    using System;

    public abstract class VideoCard : IVideoCard
    {
        public VideoCard()
        {
        }

        public abstract ConsoleColor Color { get; }

        public void Draw(string argument)
        {
            Console.ForegroundColor = this.Color;
            Console.WriteLine(argument);
            Console.ResetColor();
        }
    }
}
