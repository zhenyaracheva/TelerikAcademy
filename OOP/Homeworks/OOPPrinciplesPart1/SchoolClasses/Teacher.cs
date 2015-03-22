namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using SchoolClasses.Interfaces;

    public class Teacher : People, ITeacher, IPeople
    {
        private ICollection<IDiscipline> diciplines;

        public Teacher(string initialName)
            : base(initialName)
        {
            this.diciplines = new SortedSet<IDiscipline>();
        }

        public ICollection<IDiscipline> Diciplines
        {
            get
            {
                return new List<IDiscipline>(this.diciplines);
            }
        }

        public void AddDicipline(IDiscipline dicipline)
        {
            if (this.diciplines.Contains(dicipline))
            {
                throw new ArgumentException(string.Format("Teacher already contains {0} dicipline.", dicipline.Name));
            }

            this.diciplines.Add(dicipline);
        }

        public void RemoveDicipline(IDiscipline dicipline)
        {
            this.diciplines.Remove(dicipline);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("Teacher {0}", base.ToString()));
            output.Append(" Diciplines: ");

            if (this.diciplines.Count == 1)
            {
                output.AppendLine(string.Format("{0}",this.diciplines.First().ToString()));
            }
            else if (this.diciplines.Count != 0)
            {
                output.AppendLine();
                foreach (var dicipline in this.diciplines)
                {
                    output.AppendLine(string.Format("   *{0}",dicipline.ToString()));
                }
            }
            else
            {
                output.Append("No diciplines.");
            }

            return output.ToString().Trim();
        }
    }
}
