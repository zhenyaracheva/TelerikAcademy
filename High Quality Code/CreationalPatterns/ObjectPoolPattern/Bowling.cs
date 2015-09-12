namespace ObjectPoolPattern
{
    using System;

    public class Bowling : IDisposable
    {
        public string Player { get; set; }

        public void Dispose()
        {
            this.Player = null;
        }
    }
}
