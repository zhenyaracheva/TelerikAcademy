namespace ComputersLogic
{
    using System;

    using ComputersLogic.VideoCardTypes;

    public class Cpu : IMotherboardComponent
    {
        private const string NumberTooLowMessage = "Number too low.";
        private const string NumberTooHighMessage = "Number too high.";
        private const string SquareFormat = "Square of {0} is {1}.";
        private static readonly Random Random = new Random();

        private readonly byte numberOfBits;
        private IMotherboard motherboard;

        internal Cpu(byte numberOfCores, byte numberOfBits)
        {
            this.numberOfBits = numberOfBits;
            this.NumberOfCores = numberOfCores;
        }

        public byte NumberOfCores { get; set; }

        public void SquareNumber()
        {
            if (this.numberOfBits == 32)
            {
                this.SquareNumber(500);
            }
            else if (this.numberOfBits == 64)
            {
                this.SquareNumber(1000);
            }
            else if (this.numberOfBits == 128)
            {
                this.SquareNumber(2000);
            }
        }

        public void Rand(int minValue, int maxValue)
        {
            int randomNumber = Random.Next(minValue, maxValue + 1);

            this.motherboard.SaveRamValue(randomNumber);
        }

        public void AttachTo(IMotherboard motherboard)
        {
            this.motherboard = motherboard;
        }

        private void SquareNumber(int maxValue)
        {
            var data = this.motherboard.LoadRamValue();
            if (data < 0)
            {
                this.motherboard.DrawOnVideoCard(NumberTooLowMessage);
            }
            else if (data > maxValue)
            {
                this.motherboard.DrawOnVideoCard(NumberTooHighMessage);
            }
            else
            {
                int value = data * data;
                this.motherboard.DrawOnVideoCard(string.Format(SquareFormat, data, value));
            }
        }
    }
}
