namespace SchoolClasses
{
    using System;
    using System.Text;

    using SchoolClasses.Interfaces;

    public class Dicipline : IDiscipline, IComparable
    {
        private const int MInDiciplineNameLenght = 2;
        private const int MaxLectureAndExersiceNumber = 50;
        private const int MinLectureAndExersiceNumber = 1;

        private string name;
        private int numberOfLectures;
        private int numberOfExersices;

        public Dicipline(string initialName, int lectures, int execrsices)
        {
            this.Name = initialName;
            this.NumberOfLectures = lectures;
            this.NumberOfExersices = execrsices;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Dicipline name cannot be null or empry.");
                }

                if (value.Length < Dicipline.MInDiciplineNameLenght)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Dicipline name cannot have less than {0} symbols.", Dicipline.MInDiciplineNameLenght));
                }

                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            set
            {
                if (value < Dicipline.MinLectureAndExersiceNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Dicipline lectures cannot be smaller than {0}.", Dicipline.MinLectureAndExersiceNumber));
                }

                if (value > Dicipline.MaxLectureAndExersiceNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Dicipline lectures cannot be more than {0}", Dicipline.MaxLectureAndExersiceNumber));
                }

                this.numberOfLectures = value;
            }
        }

        public int NumberOfExersices
        {
            get
            {
                return this.numberOfExersices;
            }

            set
            {
                if (value < Dicipline.MinLectureAndExersiceNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Dicipline exersices cannot be smaller than {0}.", Dicipline.MinLectureAndExersiceNumber));
                }

                if (value > Dicipline.MaxLectureAndExersiceNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Dicipline excersices cannot be more than {0}", Dicipline.MaxLectureAndExersiceNumber));
                }

                this.numberOfExersices = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Dicipline otherDicipline = obj as Dicipline;

            if (otherDicipline != null)
            {
                return this.Name.CompareTo(otherDicipline.Name);
            }
            else
            {
                throw new ArgumentException("Object is not a Dicipline.");
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(string.Format("{0} [Lectures: {1}, Exersices: {2}]", this.Name, this.NumberOfLectures, this.NumberOfExersices));

            return output.ToString();
        }
    }
}
