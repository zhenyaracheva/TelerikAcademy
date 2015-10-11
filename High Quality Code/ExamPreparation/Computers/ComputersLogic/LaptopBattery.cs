namespace ComputersLogic
{
    public class LaptopBattery
    {
        public const int MinPercantage = 0;
        public const int MaxPercantage = 100;

        public LaptopBattery()
        {
            this.Percentage = MaxPercantage / 2;
        }

        public int Percentage { get; set; }

        public void Charge(int percentage)
        {
            this.Percentage += percentage;

            if (this.Percentage > MaxPercantage)
            {
                this.Percentage = MaxPercantage;
            }

            if (this.Percentage < MinPercantage)
            {
                this.Percentage = MinPercantage;
            }
        }
    }
}
