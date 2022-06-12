using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace MeetingPlanner.Controllers
{
    [ApiController]
    [Route("meeting")]
    public class PlanMeetingController : Controller
    {
        [HttpGet("IsPossible")]
        public IsMeetingPossibleResponse CheckIfMeetingIsPossible(
            [FromQuery(Name = "attendees")] int[] attendees,
            [FromQuery(Name = "from")] DateTime from,
            [FromQuery(Name = "to")] DateTime to)
        {
            HttpClient client = new HttpClient();
            bool allAttendeesHaveTime = attendees.All(i => GetTimeSlotsFor(from, to, client, i).Length == 0);
            return new IsMeetingPossibleResponse(allAttendeesHaveTime);

            TimeSlot[] GetTimeSlotsFor(DateTime from, DateTime to, HttpClient client, int attendee)
            {
                HttpResponseMessage response = client.Send(
                    new HttpRequestMessage(
                        HttpMethod.Get,
                        $"http://localhost:6002/timeslot/{attendee}?from={from}&to={to}"));
                string responseStringified = response.Content.ReadAsStringAsync().Result;
                TimeSlot[] timeSlots = JsonSerializer.Deserialize<TimeSlot[]>(responseStringified);
                return timeSlots;
            }
        }
    }
}
