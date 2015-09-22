namespace StrategyPattern
{
    using System;

    public class EasyComputerPlayer : IComputerPlayer
    {
        public void MakeMove()
        {
            Console.WriteLine("Computer made an Easy move.");
        }
    }
}
