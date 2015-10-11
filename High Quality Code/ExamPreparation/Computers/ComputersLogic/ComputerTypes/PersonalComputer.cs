namespace ComputersLogic.ComputerTypes
{
    using ComputersLogic.ComputerTypes.Common;
    using ComputersLogic.HardDriveTypes;
    using ComputersLogic.VideoCardTypes;

    public class PersonalComputer : Computer
    {
        private const string WinMesage = "You win!";
        private const string LoseFromat = "You didn't guess the number {0}.";

        public PersonalComputer(Cpu cpu, Ram ram, IHardDrive hardDrives, IVideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.Rand(1, 10);
            var number = Ram.LoadValue();

            if (number != guessNumber)
            {
                this.VideoCard.Draw(string.Format(LoseFromat, number));
            }
            else
            {
                this.VideoCard.Draw(WinMesage);
            }
        }
    }
}
