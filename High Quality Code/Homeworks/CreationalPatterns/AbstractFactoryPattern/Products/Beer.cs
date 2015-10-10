namespace AbstractFactoryPattern.Products
{
    using System;

    public abstract class Beer
    {
        private string madeBy;

        public Beer(double alcohol, string madeBy)
        {
            this.Alcohol = alcohol;
            this.madeBy = madeBy;
        }

        public double Alcohol { get; private set; }

        public override string ToString()
        {
            return this.GetType().Name + " - alcohol: " + this.Alcohol + "%, made by: " + this.madeBy;
        }
    }
}
