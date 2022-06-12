namespace MeetingPlanner.Controllers
{
    public class IsMeetingPossibleResponse
    {
        public bool IsPossible { get; set; }

        public IsMeetingPossibleResponse(bool isPossible)
        {
            this.IsPossible = isPossible;
        }
    }
}