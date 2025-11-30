using AcmeElevator.Models;
using System.Text.Json.Serialization;

namespace AcmeElevator.Messages
{
    public class CurrentFloorResponse
    {
        public int ElevatorId { get; set; }
        public int EstimatedArrivalSeconds { get; set; }
        public int CurrentFloor { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DirectionType Direction { get; set; }

    }
}
