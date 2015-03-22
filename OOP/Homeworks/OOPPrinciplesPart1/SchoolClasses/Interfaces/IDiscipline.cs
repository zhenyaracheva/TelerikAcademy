namespace SchoolClasses.Interfaces
{
    using System;

    public interface IDiscipline : IComparable
    {
        string Name { get; }

        int NumberOfLectures { get; set; }

        int NumberOfExersices { get; set; }
    }
}
