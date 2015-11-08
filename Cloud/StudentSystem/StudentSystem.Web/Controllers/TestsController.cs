namespace StudentSystem.Web.Controllers
{
    using Serveces.Contracts;
    using System.Web.Http;
    using System.Linq;
    using Models;
    using StudentSystem.Models;

    public class TestsController : ApiController
    {
        private ITestService testService;


        public TestsController(ITestService testService)
        {
            this.testService = testService;
        }

        public IHttpActionResult Get()
        {
            var res = this.testService.All()
                                      .ToList();

            return this.Ok(res);
        }

        public IHttpActionResult Post(TestModel testModel)
        {
            var testToAdd = new Test
            {
                Course = testModel.Course
            };

            this.testService.Add(testToAdd);

            return this.Ok("Test Added");
        }

        public IHttpActionResult Delete(TestModel test)
        {
            var testToDelete = this.testService
                                            .All()
                                            .Where(x => x.Course.Name == test.Course.Name)
                                            .FirstOrDefault();

            if (testToDelete == null)
            {
                return this.BadRequest("No test to be deleted!");
            }

            this.testService.Delete(testToDelete);

            return this.Ok("Deleted test");
        }
    }
}
