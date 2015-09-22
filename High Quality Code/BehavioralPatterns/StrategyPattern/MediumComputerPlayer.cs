namespace StrategyPattern
{
    using System;

    public class MediumComputerPlayer : IComputerPlayer
    {
        public void MakeMove()
        {
            Console.WriteLine("Computer made an Medium move.");
        }
    }
}
