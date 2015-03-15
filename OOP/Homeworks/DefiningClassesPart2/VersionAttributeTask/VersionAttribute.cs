namespace VersionAttributeTask
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum |
        AttributeTargets.Method | AttributeTargets.Struct)]

    public class VersionAttribute : Attribute
    {
        private string version;

        public VersionAttribute(string currentVersion)
        {
            this.Version = currentVersion;
        }

        public string Version
        {
            get
            {
                return this.version;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Version cannot be null or empty");
                }

                this.version = value;
            }
        }
    }
}
