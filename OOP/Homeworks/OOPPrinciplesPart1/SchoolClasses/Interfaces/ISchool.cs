namespace SchoolClasses.Interfaces
{
    using System.Collections.Generic;

    public interface ISchool
    {
        ICollection<IClass> Classes { get; }
        
        void AddClass(IClass currerntClass);

        void RemoveClass(IClass currerntClass);
    }
}
