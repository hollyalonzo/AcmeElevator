using AcmeElevator.Models;

namespace AcmeElevator.Services
{
    public interface IElevatorService
    {
        Elevator RequestPickup(int requestedFloor, DirectionType requestDirection);
        int RequestDropoff(int carId, int targetFloor);
        List<int> GetDestinations(int carId);
        int? GetNextFloor(int carId);
    }

    public class ElevatorService : IElevatorService
    {
        private static readonly List<Elevator> Elevators =
        [
            new Elevator(1, 1, ElevatorStatus.Idle, DirectionType.Up, new Queue<int>()),
            new Elevator(2, 5, ElevatorStatus.Moving, DirectionType.Up, new Queue<int>()),
            new Elevator(3, 10, ElevatorStatus.Moving, DirectionType.Down, new Queue<int>()),
            new Elevator(4, 15, ElevatorStatus.Moving, DirectionType.Up, new Queue<int>())
        ];

        public Elevator RequestPickup(int requestedFloor, DirectionType requestDirection)
        {
            // 1) Idle first
            var idleCandidate = Elevators
                .Where(e => e.Status == ElevatorStatus.Idle)
                .OrderBy(e => Math.Abs(e.CurrentFloor - requestedFloor))
                .FirstOrDefault();

            if (idleCandidate != null) { return idleCandidate; }

            // 2) Matching-direction and on-path
            var onPathCandidate = Elevators
                .Where(e => e.Status == ElevatorStatus.Moving && e.Direction == requestDirection)
                .Where(e => IsOnPath(e, requestedFloor))
                .OrderBy(e => Math.Abs(e.CurrentFloor - requestedFloor))
                .FirstOrDefault();

            if (onPathCandidate != null) { return onPathCandidate; }

            // 3) Fallback: nearest
            return FindNearestCar(requestedFloor);
        }

        public int RequestDropoff(int elevatorId, int targetFloor)
        {
            var car = Elevators[elevatorId];

            if (!car.Destinations.Contains(targetFloor))
            {
                car.Destinations.Enqueue(targetFloor);
            }

            return elevatorId;
        }

        public List<int> GetDestinations(int id)
        {
            return [.. Elevators[id].Destinations];
        }

        public int? GetNextFloor(int id)
        {
            var car = Elevators[id];
            return car.Destinations.Count != 0 ? car.Destinations.Peek() : null;

        }

        private static Elevator FindNearestCar(int requestedFloor)
        {
            return Elevators
                .OrderBy(e => Math.Abs(e.CurrentFloor - requestedFloor))
                .First();
        }

        private static bool IsOnPath(Elevator e, int requestedFloor)
        {
            return e.Direction switch
            {
                DirectionType.Up => e.CurrentFloor <= requestedFloor,
                DirectionType.Down => e.CurrentFloor >= requestedFloor,
                _ => true
            };
        }

    }
}
