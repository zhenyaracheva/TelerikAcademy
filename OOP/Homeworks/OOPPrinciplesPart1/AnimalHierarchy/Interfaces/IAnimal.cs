namespace AnimalHierarchy.Interfaces
{
    public interface IAnimal : ISound
    {
        string Name { get; }

        int Age { get; }

        Gender Gender { get; }
    }
}
