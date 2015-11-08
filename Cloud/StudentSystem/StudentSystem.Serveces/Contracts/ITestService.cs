using StudentSystem.Models;
using System.Linq;

namespace StudentSystem.Serveces.Contracts
{
    public interface ITestService
    {
        IQueryable<Test> All();

        int Add(Test course);

        void Delete(Test course);
    }
}
