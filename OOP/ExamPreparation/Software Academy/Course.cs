namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course : ICourse
    {
        private string name;
        private IList<string> topics;

        public Course(string initialName, ITeacher initialTeacher)
        {
            this.Name = initialName;
            this.Teacher = initialTeacher;
            this.topics = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public ITeacher Teacher { get; set; }

        public void AddTopic(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                throw new ArgumentNullException("Topic cannot be null or empty.");
            }

            this.topics.Add(topic);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(string.Format("{0}:", this.GetType().Name));
            result.Append(string.Format(" Name={0}", this.Name));

            if (this.Teacher != null)
            {
                result.Append(string.Format(" Teacher={0}", this.Teacher.Name));
            }

            if (this.topics.Count != 0)
            {
                string topicsAsString = string.Join(", ", this.topics);
                result.Append(string.Format("; Topics=[{0}]", topicsAsString));
            }

            return result.ToString();
        }
    }
}
