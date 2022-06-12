using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeSlot.Controllers
{
    [ApiController]
    [Route("timeslot")]
    public class TimeSlotController : Controller
    {
        private static List<TimeSlot> timeSlotStorage =
            new List<TimeSlot>() {
                    TimeSlot.Create("2022-06-11T15:43", "2022-06-11T16:43", 1),
                    TimeSlot.Create("2022-06-11T17:43", "2022-06-11T18:43", 1),
                    TimeSlot.Create("2022-06-11T19:43", "2022-06-11T19:53", 1),
                    TimeSlot.Create("2022-06-11T10:43", "2022-06-11T11:43", 4),
                    TimeSlot.Create("2022-06-11T15:43", "2022-06-11T16:43", 4),
                    TimeSlot.Create("2022-06-11T16:43", "2022-06-11T16:43", 5),
                    TimeSlot.Create("2022-06-11T17:20", "2022-06-11T16:43", 5),
                    TimeSlot.Create("2022-06-11T09:00", "2022-06-11T10:40", 6),
                    TimeSlot.Create("2022-06-11T13:12", "2022-06-11T18:43", 6),
                    TimeSlot.Create("2022-06-11T22:45", "2022-06-11T23:43", 6),
                    TimeSlot.Create("2022-06-11T16:43", "2022-06-11T16:40", 7),
                    TimeSlot.Create("2022-06-11T15:12", "2022-06-11T16:40", 8),
                    TimeSlot.Create("2022-06-11T12:43", "2022-06-11T15:43", 9),
                    TimeSlot.Create("2022-06-11T16:43", "2022-06-11T18:43", 9)
                };

        [HttpGet("{ownerId}")]
        public TimeSlot[] GetTimeSlots([FromRoute] int ownerId, [FromQuery] DateTime from, [FromQuery]  DateTime to)
        {
            return timeSlotStorage
                .Where(t => t.OwnerId == ownerId)
                .Where(t => OverlapsWith(from, to, t))
                .ToArray();

            static bool OverlapsWith(DateTime from, DateTime to, TimeSlot timeSlot)
            {
                return (timeSlot.From >= from && timeSlot.From < to) || (timeSlot.To <= to && timeSlot.To >= from);
            }
        }
    }
}
