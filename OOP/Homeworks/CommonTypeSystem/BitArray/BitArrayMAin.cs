using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray
{
    public class BitArrayMain
    {
        static void Main(string[] args)
        {
            var first = new BitArray64(5555555555555);
            var second = new BitArray64(2);

            Console.WriteLine("Test: .ToString() ");
            Console.WriteLine(first.ToString());
            Console.WriteLine(second.ToString());
            Console.WriteLine();

            Console.WriteLine("Test: Indexer:");
            Console.WriteLine(first[62]);
            Console.WriteLine(first[63]);
            Console.WriteLine();

            Console.WriteLine("Test: .GetHashCode():");
            Console.WriteLine(first.GetHashCode());
            Console.WriteLine(second.GetHashCode());
            Console.WriteLine();

            Console.WriteLine("Test .Equals():");
            Console.WriteLine(first.Equals(second));
            Console.WriteLine();

            Console.WriteLine("Test == operator:");
            Console.WriteLine(first == second);
            Console.WriteLine();

            Console.WriteLine("Test != operator:");
            Console.WriteLine(first != second);
            Console.WriteLine();

            Console.WriteLine("Test: IEnumeble<int>");

            foreach (var bit in first)
            {
                Console.Write(bit + " ");
            }
            Console.WriteLine();
        }
    }
}
