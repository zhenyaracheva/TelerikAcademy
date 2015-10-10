namespace CommandPattern
{
    using System;
    using System.Collections.Generic;

    using CommandPattern.Commands;
    using CommandPattern.Commands.Common;
    using CommandPattern.Devices;

    public class BehavioralPatternsExample
    {
        public static void Main(string[] args)
        {
            IList<ICommand> commands = new List<ICommand>();

            var device = new Radio();
            //// var device = new Television();

            var deviceOn = new TurnOnCommand(device);
            var deviceOff = new TurnOffCommand(device);
            var deviceVolumeUp = new VolumeUpCommand(device);
            var deviceVolumeDown = new VolumeDownCommand(device);

            commands.Add(deviceOn);
            commands.Add(deviceVolumeUp);
            commands.Add(deviceVolumeUp);
            commands.Add(deviceVolumeUp);
            commands.Add(deviceVolumeDown);
            commands.Add(deviceOff);

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Commands:");
            Console.WriteLine("----------------------------------");
            for (int i = 0; i < commands.Count; i++)
            {
                commands[i].Execute();
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Undo commands:");
            Console.WriteLine("----------------------------------");
            for (int i = commands.Count - 1; i >= 0; i--)
            {
                commands[i].Undo();
            }
        }
    }
}
