namespace CompareSimpleMath
{
    using System;

    public class TestPerformance
    {
        public static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("TEST SIMPLE MATH");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("TEST INT");
            Console.WriteLine("----------------------------------------------");
            TestMath<int>.CompareSimpleMath(100, 5, 100);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("TEST LONG");
            Console.WriteLine("----------------------------------------------");
            TestMath<long>.CompareSimpleMath(100, 5, 100);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("TEST FLOAT");
            Console.WriteLine("----------------------------------------------");
            TestMath<float>.CompareSimpleMath(100, 5, 100);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("TEST DOUBLE");
            Console.WriteLine("----------------------------------------------");
            TestMath<double>.CompareSimpleMath(100, 5, 100);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("TEST DECIMAL");
            Console.WriteLine("----------------------------------------------");
            TestMath<decimal>.CompareSimpleMath(100, 5, 100);

            Console.WriteLine();
            Console.WriteLine("TEST ADVANCED MATH");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("TEST FLOAT");
            Console.WriteLine("----------------------------------------------");
            TestMath<float>.CompareAdvancesMath("float", 5, 100);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("TEST DOUBLE");
            Console.WriteLine("----------------------------------------------");
            TestMath<double>.CompareAdvancesMath("double", 5, 100);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("TEST DECIMAL");
            Console.WriteLine("----------------------------------------------");
            TestMath<decimal>.CompareAdvancesMath("decimal", 5, 100); 
        }
    }
}
