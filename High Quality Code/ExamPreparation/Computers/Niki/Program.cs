namespace Computers.UI
{
    using System;

    using ComputersLogic;
    using ComputersLogic.ComputerTypes;
    using ComputersLogic.Manufacturers;

    public class Computers
    {
        private static PersonalComputer pc;
        private static Laptop laptop;
        private static Server server;

        public static void Main()
        {
            var manufacturerFactory = new ManufactuerFactory();
            var userManufacturer = Console.ReadLine();

            IManufacturer manufacturer = manufacturerFactory.GetManufacturer(userManufacturer);
            var parser = new CommandParser();

            pc = manufacturer.CreatePC();
            server = manufacturer.CreateServer();
            laptop = manufacturer.CreateLaptop();

            while (true)
            {
                var userCommand = Console.ReadLine();
                var command = parser.ParseCommand(userCommand);

                if (command.Name == "Exit")
                {
                    break;
                }
                else
                {
                    ProcessCommand(command);
                }
            }
        }

        private static void ProcessCommand(ICommand command)
        {
            if (command.Name == "Charge")
            {
                laptop.ChargeBattery(command.Argument);
            }
            else if (command.Name == "Process")
            {
                server.Process(command.Argument);
            }
            else if (command.Name == "Play")
            {
                pc.Play(command.Argument);
            }
        }
    }
}