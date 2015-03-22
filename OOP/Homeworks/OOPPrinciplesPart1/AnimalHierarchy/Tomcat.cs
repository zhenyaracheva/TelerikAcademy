namespace AnimalHierarchy
{
    using AnimalHierarchy.Interfaces;

    public class Tomcat : Cat, IAnimal, ISound
    {
        public Tomcat(string name, int age)
            : base(name, age, Gender.Male)
        {
        }

        public override string MySound()
        {
            return "Myauuuuuuuuuu!";
        }
    }
}
