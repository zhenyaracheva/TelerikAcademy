namespace VersionAttributeTask
{
    using System;
    using System.Reflection;

    [Version("2.11")]
    public class AttributesMain
    {
        public static void Main()
        {
            Type type = typeof(AttributesMain);
            var attributes = type.GetCustomAttributes<VersionAttribute>();

            foreach (var attribute in attributes)
            {
                Console.WriteLine(attribute.Version);
            }
        }
    }
}
