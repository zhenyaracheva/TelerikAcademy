namespace StudentSystem.Serveces.Contracts
{
    using Models;
    using System.Linq;

    public interface ICourseService
    {
        IQueryable<Course> All();

        string Add(string name, string description);

        IQueryable<Course> ById(string id);

        void Delete(Course course);
    }
}
