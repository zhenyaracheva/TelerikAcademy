namespace StrategyPattern
{
    public class Game
    {
        public Game(IComputerPlayer player)
        {
            this.ComputerPlayer = player;
        }

        public IComputerPlayer ComputerPlayer { get; set; }

        public void Move()
        {
            this.ComputerPlayer.MakeMove();
        }
    }
}
