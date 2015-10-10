namespace Events
{
    using System;
    using Wintellect.PowerCollections;

    internal class EventHolder
    {
        private MultiDictionary<string, Event> fromTitle = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> fromDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.fromTitle.Add(title.ToLower(), newEvent);
            this.fromDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in this.fromTitle[title])
            {
                removed++;
                this.fromDate.Remove(eventToRemove);
            }

            this.fromTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.fromDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
