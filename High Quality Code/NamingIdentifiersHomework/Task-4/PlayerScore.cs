namespace Minesweeper
{
    public class PlayerScore
    {
        private string player;
        private int points;

        public PlayerScore(string player, int points)
        {
            this.Player = player;
            this.Points = points;
        }

        public string Player
        {
            get
            {
                return this.player;
            }

            set
            {
                this.player = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                this.points = value;
            }
        }
    }
}
