namespace Events
{
    using System;
    using System.Threading;

    public class Timer
    {
        public event TickHandler Tick;

        public delegate void TickHandler(Timer currentTimer, EventArgs currentEvent);

        private EventArgs currentEvent = null;

        public void Start(int time)
        {
            while (true)
            {
                Thread.Sleep(time * 1000);
                if (this.Tick != null)
                {
                    this.Tick(this, this.currentEvent);
                }
            }
        }
    }
}
