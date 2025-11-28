using AcmeElevator.Messages;
using AcmeElevator.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcmeElevator.Controllers
{
    [ApiController]
    [Route("api/elevators")]
    public class ElevatorController : ControllerBase
    {
        private readonly IElevatorService _service;

        public ElevatorController(IElevatorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Process an elevator request for pickup
        /// </summary>
        /// <param name="request">floor and direction</param>
        /// <returns>elevator assigned with data points</returns>
        [HttpPost("pickup")]
        public ActionResult<CurrentFloorResponse> RequestPickup([FromBody] CurrentFloorRequest request)
        {
            //todo: add request validation

            var assignedElevator = _service.RequestPickup(request.Floor, request.Direction);

            var response = new CurrentFloorResponse
            {
                ElevatorId = assignedElevator.ElevatorId,
                EstimatedArrivalSeconds = assignedElevator.EstimatedArrivalTime(request.Floor),
                CurrentFloor = assignedElevator.CurrentFloor,
                Direction = request.Direction
            };

            return Ok(response);
        }

        /// <summary>
        /// Process an elevator request for dropoff
        /// </summary>
        /// <param name="request">elevatorId and floor</param>
        /// <returns>elevatorId</returns>
        [HttpPost("dropoff")]
        public ActionResult<int> RequestDropoff([FromBody] DropOffRequest request)
        {
            //todo: add request validation

            var assignedElevator = _service.RequestDropoff(request.ElevatorId, request.TargetFloor);

            return Ok(assignedElevator);
        }

        /// <summary>
        /// Get destinations for an elevator
        /// </summary>
        /// <param name="elevatorId">id of elevator</param>
        /// <returns>a list of destinations for an elevator</returns>
        [HttpGet("{elevatorId}/destinations")]
        public ActionResult<List<int>> GetDestinations(int elevatorId)
        {
            var floors = _service.GetDestinations(elevatorId);
            return Ok(floors);
        }

        /// <summary>
        /// Get next floor for an eleavator to service
        /// </summary>
        /// <param name="elevatorId">id of elevator</param>
        /// <returns>next floor</returns>
        [HttpGet("{elevatorId}/next")]
        public ActionResult<int?> GetNextFloor(int elevatorId)
        {
            var nextFloor = _service.GetNextFloor(elevatorId);
            return Ok(nextFloor);
        }

    }
}
