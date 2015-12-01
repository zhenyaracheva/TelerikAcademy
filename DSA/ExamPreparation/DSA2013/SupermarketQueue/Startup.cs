namespace SupermarketQueue
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Startup
    {
        public static void Main()
        {
            var data = new BigList<string>();
            var dict = new Dictionary<string, int>();

            var input = Console.ReadLine();
            var result = new StringBuilder();

            while (true)
            {
                var command = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var commandName = command[0];

                if (commandName == "Append")
                {
                    var name = command[1];
                    data.Add(name);

                    if (!dict.ContainsKey(name))
                    {
                        dict.Add(name, 0);
                    }

                    dict[name]++;
                    result.AppendLine("OK");
                }
                else if (commandName == "Insert")
                {
                    var index = int.Parse(command[1]);

                    if (index > data.Count)
                    {
                        result.AppendLine("Error");
                    }
                    else
                    {
                        var name = command[2];
                        data.Insert(index, name);

                        if (!dict.ContainsKey(name))
                        {
                            dict.Add(name, 0);
                        }

                        dict[name]++;
                        result.AppendLine("OK");
                    }
                }
                else if (commandName == "Find")
                {
                    var name = command[1];

                    if (!dict.ContainsKey(name))
                    {
                        result.AppendLine("0");
                    }
                    else
                    {
                        result.AppendLine(dict[name].ToString());
                    }
                }
                else if (commandName == "Serve")
                {
                    var number = int.Parse(command[1]);

                    if (number > data.Count)
                    {
                        result.AppendLine("Error");
                    }
                    else
                    {
                        var served = new StringBuilder();

                        for (int i = 0; i < number; i++)
                        {
                            var person = data[0];
                            data.RemoveAt(0);
                            served.Append(person + " ");
                            dict[person]--;
                        }
                        
                        result.AppendLine(served.ToString());
                    }
                }
                else if (commandName == "End")
                {
                    break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
