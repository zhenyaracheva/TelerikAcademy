namespace PersonTask
{
    public class Person
    {
            public Gender Gender { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }

            public Person CreatePerson(int age)
            {
                Person newPerson = new Person();
                newPerson.Age = age;
                if (age % 2 == 0)
                {
                    newPerson.Name = "TheBigBro";
                    newPerson.Gender = Gender.Male;
                }
                else
                {
                    newPerson.Name = "TheBigChick";
                    newPerson.Gender = Gender.Female;
                }

                return newPerson;
            }
    }
}
