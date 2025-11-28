using AcmeElevator.Models;

namespace AcmeElevator.Messages
{
    public class CurrentFloorResponse
    {
        public int ElevatorId { get; set; }
        public int EstimatedArrivalSeconds { get; set; }
        public int CurrentFloor { get; set; }
        public DirectionType Direction { get; set; }

    }
}
