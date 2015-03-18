namespace Events
{
    using System;

    public class Output
    {
        public void Subscribe(Timer currentTimer)
        {
            currentTimer.Tick += new Timer.TickHandler(this.PrintDateTime);
        }

        private void PrintDateTime(Timer currentTimer, EventArgs e)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
