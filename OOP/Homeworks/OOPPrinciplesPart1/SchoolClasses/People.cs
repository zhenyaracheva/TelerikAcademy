namespace SchoolClasses
{
    using System;

    using SchoolClasses.Interfaces;

    public abstract class People : IPeople
    {
        private string name;

        public People(string initialName)
        {
            this.Name = initialName;
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
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                if (value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("Name cannot have less than 2 symbols.");
                }

                this.name = value;
            }
        }

        public override string ToString()
        {
            return string.Format("name: {0}", this.Name);
        }
    }
}
