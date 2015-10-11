namespace ComputersLogic.Manufacturers
{
    using ComputersLogic.ComputerTypes;

    public interface IManufacturer
    {
        PersonalComputer CreatePC();

        Laptop CreateLaptop();

        Server CreateServer();
    }
}
