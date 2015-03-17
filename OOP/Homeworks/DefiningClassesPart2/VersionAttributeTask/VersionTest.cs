namespace VersionAttributeTask
{
    using System;

     [Version]
    public class VersionTest
    {
        private string version;

        public VersionTest(string currentVersion)
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
