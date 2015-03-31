namespace PersonClass
{
    using System;

    public class Person
    {
        private string name;

        public Person(string initialName)
        {
            this.Name = initialName;
        }

        public Person(string initialName, int initialAge)
        {
            this.Name = initialName;
            this.Age = initialAge;
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
                    throw new ArgumentNullException("Name cannot be null or empry.");
                }

                this.name = value;
            }
        }

        public int? Age { get; set; }

        public override string ToString()
        {
            return this.Age == null ? this.Name : (this.Name + " " + this.Age);
        }
    }
}
