// Problem 3. Animal hierarchy
// 
// Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. Dogs, 
// frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). Kittens 
// and tomcats are cats. All animals are described by age, name and sex. Kittens can be only female and 
// tomcats can be only male. Each animal produces a specific sound.
// Create arrays of different kinds of animals and calculate the average age of each kind of animal using 
// a static method (you may use LINQ).
namespace AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AnimalHierarchy.Interfaces;

    public class AnimalHierarchyMain
    {
        public static void Main()
        {
            var animals = new List<IAnimal>();
            animals.Add(new Kitten("Maca", 3));
            animals.Add(new Kitten("Glezla", 5));
            animals.Add(new Kitten("Ligla", 1));
            animals.Add(new Tomcat("Sylvestar", 2));
            animals.Add(new Tomcat("Tom", 7));
            animals.Add(new Tomcat("Garfyeld", 5));
            animals.Add(new Dog("Snoopy", 10, Gender.Male));
            animals.Add(new Dog("Lacy", 9, Gender.Female));
            animals.Add(new Dog("Rex", 2, Gender.Male));
            animals.Add(new Dog("Kudjo", 20, Gender.Male));
            animals.Add(new Dog("MArley", 5, Gender.Female));
            animals.Add(new Frog("Kurmit", 4, Gender.Male));

            double averageAgeKitten = animals.OfType<Kitten>().Cast<Kitten>().Average(x => x.Age);
            double averageAgeTomcat = animals.Where(x => x is Tomcat).Average(x => x.Age);
            double averageAgeDog = animals.Where(x => x is Dog).Average(x => x.Age);
            double averageAgeFrog = animals.Where(x => x is Frog).Average(x => x.Age);

            Console.WriteLine("Kitten average age: {0}", averageAgeKitten);
            Console.WriteLine("Tomcat average age: {0}", averageAgeTomcat);
            Console.WriteLine("Dog average age: {0}", averageAgeDog);
            Console.WriteLine("Frog average age: {0}", averageAgeFrog);
        }
    }
}
