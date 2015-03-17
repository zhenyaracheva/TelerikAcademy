namespace VersionAttributeTask
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum |
        AttributeTargets.Method | AttributeTargets.Struct)]

    public class VersionAttribute : Attribute
    {
    }
}
