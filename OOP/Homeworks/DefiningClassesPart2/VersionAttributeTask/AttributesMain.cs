namespace VersionAttributeTask
{
    using System;

    public class AttributesMain
    {
        public static void Main()
        {
            var newVersion = new VersionTest("2.11");

            Type type = typeof(VersionTest);
            var attributes = type.GetProperties();

            foreach (var attribute in attributes)
            {
                Console.WriteLine(attribute.Name + ": " + attribute.GetValue(newVersion));
            }
        }
    }
}
