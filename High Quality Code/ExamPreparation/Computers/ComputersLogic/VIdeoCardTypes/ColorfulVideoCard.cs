namespace ComputersLogic.VideoCardTypes
{
    using System;

    public class ColorfulVideoCard : VideoCard
    {
        private ConsoleColor color;

        public ColorfulVideoCard()
        {
            this.color = ConsoleColor.Green;
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
