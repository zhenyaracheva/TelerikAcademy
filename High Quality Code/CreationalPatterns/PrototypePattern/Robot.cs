namespace PrototypePattern
{
    public class Robot : RobotPrototype
    {
        public Robot(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return "I'm " + this.GetType().Name + ", my name is " + this.Name;
        }

        public override Robot Clone()
        {
            return this.MemberwiseClone() as Robot;
        }
    }
}
