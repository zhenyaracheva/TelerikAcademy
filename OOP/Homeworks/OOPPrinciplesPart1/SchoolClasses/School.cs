namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using SchoolClasses.Interfaces;

    public class School : ISchool
    {
        private ICollection<IClass> classes;

        public School()
        {
            this.classes = new List<IClass>();
        }

        public ICollection<IClass> Classes
        {
            get
            {
                return new List<IClass>(this.classes);
            }
        }

        public void AddClass(IClass currerntClass)
        {
            if (this.classes.Contains(currerntClass))
            {
                throw new ArgumentException(string.Format("School alredy contains {0} class.", currerntClass.Identifier));
            }

            this.classes.Add(currerntClass);
        }

        public void RemoveClass(IClass currerntClass)
        {
            this.classes.Remove(currerntClass);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            if (this.classes.Count != 1)
            {
                output.Append("School classes: ");
                if (this.classes.Count != 0)
                {
                    output.AppendLine();

                    foreach (var cl in this.classes)
                    {
                        output.AppendLine(string.Format(" {0}", cl.ToString()));
                    }
                }
                else
                {
                    output.AppendLine("No classes.");
                }
            }
            else
            {
                output.AppendLine("School class:");
                output.AppendLine(string.Format(" {0}", this.classes.First().ToString()));
            }

            return output.ToString().Trim();
        }
    }
}
