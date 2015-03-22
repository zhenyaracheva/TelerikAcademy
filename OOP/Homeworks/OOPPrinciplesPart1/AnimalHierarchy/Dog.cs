namespace AnimalHierarchy
{
    using AnimalHierarchy.Interfaces;

    public class Dog : Animal, IAnimal, ISound
    {
        public Dog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override string MySound()
        {
            return "Bau-bauuuuuu!";
        }
    }
}
