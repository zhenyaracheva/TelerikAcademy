namespace Events
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int fromDate = this.date.CompareTo(other.date);
            int fromTitle = this.title.CompareTo(other.title);
            int fromLocation = this.location.CompareTo(other.location);
            if (fromDate == 0)
            {
                if (fromTitle == 0)
                {
                    return fromLocation;
                }
                else
                {
                    return fromTitle;
                }
            }
            else
            {
                return fromDate;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);
            if (this.location != null && this.location != string.Empty)
            {
                toString.Append(" | " + this.location);
            }

            return toString.ToString();
        }
    }
}