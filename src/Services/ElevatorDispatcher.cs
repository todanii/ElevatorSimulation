using ElevatorSimulation.Interfaces;

namespace ElevatorSimulation.Services
{
    public class ElevatorDispatcher : IElevatorDispatcher
    {
        private readonly List<IElevator> _elevators;

        public ElevatorDispatcher(List<IElevator> elevators)
        {
            _elevators = elevators;
        }

        public void RequestElevator(int floor, int passengers)
        {
            var availableElevator = _elevators
                .Where(e => !e.IsMoving && e.CanAddPassengers(passengers) && e.AllowedFloors.Contains(floor))
                .OrderBy(e => Math.Abs(e.CurrentFloor - floor))
                .FirstOrDefault();

            if (availableElevator == null)
            {
                Console.WriteLine("No available elevator. Please wait.");
                return;
            }

            availableElevator.MoveToFloor(floor);
            Console.WriteLine($"Elevator assigned from floor {availableElevator.CurrentFloor} to {floor}");
            availableElevator.LoadPassengers(passengers);
        }

        public void ShowStatus()
        {
            foreach (var elevator in _elevators)
            {
                Console.WriteLine($"Elevator {elevator.Id} - Floor: {elevator.CurrentFloor}, Direction: {elevator.Direction}, Passengers:  {elevator.PassengerCount}/{elevator.MaxPassengers}");
            }
        }
    }
}