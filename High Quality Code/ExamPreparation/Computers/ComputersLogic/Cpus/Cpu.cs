namespace ComputersLogic
{
    using System;

    using ComputersLogic.VideoCardTypes;

    public abstract class Cpu : IMotherboardComponent
    {
        private const string NumberTooLowMessage = "Number too low.";
        private const string NumberTooHighMessage = "Number too high.";
        private const string SquareFormat = "Square of {0} is {1}.";
        private static readonly Random Random = new Random();

        private IMotherboard motherboard;

        public Cpu(int numberOfCores)
        {
            this.NumberOfCores = numberOfCores;
        }

        public int NumberOfCores { get; set; }

        public abstract int MaxBitValue { get; }

        public void SquareNumber()
        {
           this.SquareNumber(this.MaxBitValue);
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
