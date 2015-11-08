namespace Phones
{
    public class Person
    {
        public string Name { get; set; }

        public string Town { get; set; }

        public string PhoneNumber { get; set; }

        public override int GetHashCode()
        {
            return (int)(long.Parse(this.PhoneNumber) / 2);
        }

        public override bool Equals(object person)
        {
            var otherPerson = person as Person;

            var result = this.PhoneNumber == otherPerson.PhoneNumber &&
                          this.Name == otherPerson.Name &&
                          this.Town == otherPerson.Town;

            return result;
        }

        public override string ToString()
        {
            return this.Name + " | " + this.Town + " | " + this.PhoneNumber;
        }
    }
}
