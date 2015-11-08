namespace StudentSystem.Web.Controllers
{
    using Data.Repositories;
    using StudentSystem.Models;
    using Serveces.Contracts;
    using System.Web.Http;
    using System.Linq;
    using Models;

    public class CoursesController : ApiController
    {
        private ICourseService courseService;
        
        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        
        public IHttpActionResult Get()
        {
            var res = this.courseService.All()
                                        .ToList();

            return this.Ok(res);
        }

        public IHttpActionResult Post(CourseModel courseModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid course input!");
            }

            if (this.courseService.All().Any(x => x.Name == courseModel.Name))
            {
                return this.BadRequest(courseModel.Name + " is already added!");
            }

            var addedCourseName = this.courseService.Add(courseModel.Name, courseModel.Description);

            return this.Ok("Added course: " + addedCourseName);
        }

        public IHttpActionResult Delete(string id)
        {
            var element = this.courseService
                              .ById(id)
                              .FirstOrDefault();

            if (element == null)
            {
                return this.BadRequest("Course" + element.Name + " doesn't exist!");
            }

            this.courseService.Delete(element);

            return this.Ok("Deleted course " + element.Name);
        }
    }
}
