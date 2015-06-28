namespace PersonTask
{
    using System;

    public class RefactorClassPerson
    {
        public static void Main(string[] args)
        {
            var testFemalePersonCreating = new Person().CreatePerson(159);
            Console.WriteLine(testFemalePersonCreating.Gender + " person named " + testFemalePersonCreating.Name + ", age " + testFemalePersonCreating.Age + " was created!");
            var testMalePersonCreating = new Person().CreatePerson(158);
            Console.WriteLine(testMalePersonCreating.Gender + " person named " + testMalePersonCreating.Name + ", age " + testMalePersonCreating.Age + " was created!");
        }
    }
}
