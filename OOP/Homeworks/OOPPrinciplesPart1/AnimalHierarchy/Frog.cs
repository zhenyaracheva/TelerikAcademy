namespace AnimalHierarchy
{
    using AnimalHierarchy.Interfaces;

    public class Frog : Animal, IAnimal, ISound
    {
        public Frog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override string MySound()
        {
            return "Kvak-kvak!";      
        }
    }
}
