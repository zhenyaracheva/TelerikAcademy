namespace ComputersLogic.VideoCardTypes
{
    using System;

    public class MonochromeVideoCard : VideoCard
    {
        private ConsoleColor color;

        public MonochromeVideoCard()
        {
            this.color = ConsoleColor.Gray;
        }

        public override ConsoleColor Color
        {
            get
            {
                return this.color;
            }
        }
    }
}
