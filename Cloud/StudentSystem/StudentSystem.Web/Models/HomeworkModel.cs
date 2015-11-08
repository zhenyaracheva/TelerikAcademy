namespace StudentSystem.Web.Models
{
    using StudentSystem.Models;
    using System;

    public class HomeworkModel
    {
        public string FileUrl { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}