using AcmeElevator.Models;

namespace AcmeElevator.Messages
{
    public class CurrentFloorRequest
    {
        public int Floor { get; set; }
        public DirectionType Direction { get; set; }
    }
}
