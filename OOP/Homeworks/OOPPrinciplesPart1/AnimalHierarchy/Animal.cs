namespace AnimalHierarchy
{
    using System;

    using AnimalHierarchy.Interfaces;

    public abstract class Animal : IAnimal, ISound
    {
        private string name;
        private int age;
        private Gender gender;

        public Animal(string initialName, int initialAge, Gender currerntGender)
        {
            this.Name = initialName;
            this.Age = initialAge;
            this.Gender = currerntGender;
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

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be less than 0.");
                }

                this.age = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return this.gender;
            }

            private set
            {
                this.gender = value;
            }
        }

        public abstract string MySound();
    }
}
