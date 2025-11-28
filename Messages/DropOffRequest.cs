namespace AcmeElevator.Messages
{
    public class DropOffRequest
    {
        public int ElevatorId { get; set; }
        public int TargetFloor { get; set; }
    }
}
