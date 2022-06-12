using System;

namespace TimeSlot.Controllers
{
    public class TimeSlot
    {
        public TimeSlot(int ownerId, DateTime from, DateTime to)
        {
            OwnerId = ownerId;
            From = from;
            To = to;
        }

        public int OwnerId { get; }
        public DateTime From { get; }
        public DateTime To { get; }

        internal static TimeSlot Create(string from, string to, int ownderId)
        {
            return new TimeSlot(ownderId, DateTime.Parse(from), DateTime.Parse(to));
        }
    }
}
