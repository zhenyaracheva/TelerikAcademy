namespace Phones
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            var info = File.ReadAllLines("../../phones.txt");
            var phonebook = ReadPhonebook(info);
            ExecuteCommands(phonebook);
        }

        private static void ExecuteCommands(ISet<Person> phonebook)
        {
            var commandsPath = "../../commands.txt";
            var commands = File.ReadAllLines(commandsPath);

            foreach (var command in commands)
            {
                Console.WriteLine("Command: " + command);
                var commandParts = command.Split(new[] { "(", ")", "find", "," }, StringSplitOptions.RemoveEmptyEntries);

                if (commandParts.Length == 2)
                {
                    FindPersonByNameAndTown(commandParts[0].Trim(), commandParts[1].Trim(), phonebook);
                }
                else
                {
                    FndPersonByName(commandParts[0].Trim(), phonebook);
                }

                Console.WriteLine("---------------------------------------------");
            }
        }

        private static void FindPersonByNameAndTown(string name, string town, ISet<Person> phonebook)
        {
            var counter = 0;

            foreach (var person in phonebook)
            {
                if (person.Name.ToLower().Contains(name.ToLower()) && person.Town.ToLower() == town.ToLower())
                {
                    counter++;
                    Console.WriteLine(person.ToString());
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("No record with name {0} and town {1}", name, town);
            }
        }

        private static void FndPersonByName(string name, ISet<Person> phonebook)
        {
            var counter = 0;

            foreach (var person in phonebook)
            {
                if (person.Name.ToLower().Contains(name.ToLower()))
                {
                    counter++;
                    Console.WriteLine(person.ToString());
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("No record with name " + name);
            }
        }

        private static ISet<Person> ReadPhonebook(string[] info)
        {
            var phonebook = new HashSet<Person>();

            foreach (var line in info)
            {
                var currentInfo = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var number = string.Join(string.Empty, currentInfo[2].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                var person = new Person
                {
                    Name = currentInfo[0].Trim(),
                    Town = currentInfo[1].Trim(),
                    PhoneNumber = number
                };

                phonebook.Add(person);
            }

            return phonebook;
        }
    }
}
