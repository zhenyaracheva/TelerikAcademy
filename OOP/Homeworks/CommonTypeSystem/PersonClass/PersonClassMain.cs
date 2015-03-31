namespace PersonClass
{
    using System;

    public class PersonClassMain
    {
        public static void Main()
        {
            var firstPerson = new Person("Ivan");
            var secondPerson = new Person("Ivan", 22);

            Console.WriteLine(firstPerson.ToString());
            Console.WriteLine(secondPerson.ToString());
        }
    }
}
