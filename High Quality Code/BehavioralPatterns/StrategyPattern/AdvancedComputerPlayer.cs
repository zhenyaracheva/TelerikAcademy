namespace StrategyPattern
{
    using System;

    public class AdvancedComputerPlayer : IComputerPlayer
    {
        public void MakeMove()
        {
            Console.WriteLine("Computer made an Advanced move.");
        }
    }
}
