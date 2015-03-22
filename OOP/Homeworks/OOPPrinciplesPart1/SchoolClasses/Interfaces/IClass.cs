namespace SchoolClasses.Interfaces
{
    using System.Collections.Generic;

    public interface IClass
    {
        ICollection<ITeacher> Teachers { get; }

        string Identifier { get; }

        ICollection<IStudent> Students { get; }

        void AddTeacher(ITeacher teacher);

        void RemoveTeacher(ITeacher teacher);

        void AddStudent(IStudent student);

        void RemoveStudent(IStudent student);
    }
}
