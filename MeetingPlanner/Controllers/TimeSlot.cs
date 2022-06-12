using System;

namespace MeetingPlanner.Controllers
{
    internal class TimeSlot
    {
        public int OwnerId { get; }
        public DateTime From { get; }
        public DateTime To { get; }
    }
}