namespace SchoolClasses.Interfaces
{
    using System.Collections.Generic;

    public interface ITeacher : IPeople
    {
        ICollection<IDiscipline> Diciplines { get; }

        void AddDicipline(IDiscipline dicipline);

        void RemoveDicipline(IDiscipline dicipline);
    }
}
