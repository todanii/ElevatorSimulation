using ElevatorSimulation.Enums;

namespace ElevatorSimulation.Interfaces
{
    public interface IElevator
    {
        public int Id { get; }
        public int CurrentFloor { get; }
        List<int> AllowedFloors { get; }
        public Direction Direction { get; }
        public int PassengerCount { get; }
        public int MaxPassengers { get; }
        public bool IsMoving => Direction != Direction.None;

        void MoveToFloor(int targetFloor);
        bool CanAddPassengers(int count);
        void LoadPassengers(int count);
    }
}
