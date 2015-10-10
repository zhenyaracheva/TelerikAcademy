namespace StrategyPattern
{
    using System;

    public class StrategyPatternExample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Start game with easy player");
            var game = new Game(new EasyComputerPlayer());
            game.Move();

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Change player to medium player");
            game.ComputerPlayer = new MediumComputerPlayer();
            game.Move();

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Change player to advanced player");
            game.ComputerPlayer = new AdvancedComputerPlayer();
            game.Move();
        }
    }
}
