namespace AnimalHierarchy
{
    using AnimalHierarchy.Interfaces;

    public abstract class Cat : Animal, IAnimal, ISound
    {
        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }
    }
}
