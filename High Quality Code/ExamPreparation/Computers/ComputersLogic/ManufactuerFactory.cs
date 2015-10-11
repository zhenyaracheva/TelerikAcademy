namespace ComputersLogic
{
    using System;

    using ComputersLogic.Manufacturers;

    public class ManufactuerFactory
    {
        private const string HpManufacturer = "HP";
        private const string DellManufacturer = "Dell";
        private const string LenovoManufacturer = "Lenovo";
        private const string InvalidManufacturerMessage = "Invalid manufacturer!";

        public IManufacturer GetManufacturer(string manufacturer)
        {
            if (manufacturer == ManufactuerFactory.HpManufacturer)
            {
                return new HpManufacturer();
            }
            else if (manufacturer == ManufactuerFactory.DellManufacturer)
            {
                return new DellManufacturer();
            }
            else if (manufacturer == ManufactuerFactory.LenovoManufacturer)
            {
                return new LenovoManufacturer();
            }
            else
            {
                throw new ArgumentOutOfRangeException(ManufactuerFactory.InvalidManufacturerMessage);
            }
        }
    }
}
