namespace AnimalHierarchy
{
    using AnimalHierarchy.Interfaces;

    public class Kitten : Cat, IAnimal, ISound
    {
        public Kitten(string name, int age)
            : base(name, age, Gender.Female)
        {
        }

        public override string MySound()
        {
            return "Myrrr - myauu!";
        }
    }
}
