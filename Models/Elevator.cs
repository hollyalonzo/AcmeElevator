namespace AcmeElevator.Models
{
    public class Elevator
    {
        public int ElevatorId { get; }
        public int CurrentFloor { get; private set; }
        public ElevatorStatus Status { get; private set; }
        public DirectionType Direction { get; private set; }
        public Queue<int> Destinations { get; set; }

        public Elevator(int elevatorId, int currentFloor, ElevatorStatus status, DirectionType direction, Queue<int> destinations)
        {
            ElevatorId = elevatorId;
            CurrentFloor = currentFloor;
            Status = status;
            Direction = direction;
            Destinations = destinations;
        }

        public int EstimatedArrivalTime(int requestedFloor)
        {
            // Assume 3 seconds per floor travel time
            return Math.Abs(CurrentFloor - requestedFloor) * 3;
        }
    }
}
