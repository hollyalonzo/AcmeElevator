using AcmeElevator.Models;
using System.Text.Json.Serialization;

namespace AcmeElevator.Messages
{
    public class CurrentFloorRequest
    {
        public int Floor { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DirectionType Direction { get; set; }
    }
}
