using ElevatorSimulation.Enums;
using ElevatorSimulation.Interfaces;

namespace ElevatorSimulation.Models
{
    public abstract class ElevatorBase : IElevator
    {
        public int Id { get; }
        public int CurrentFloor { get; private set; }
        public List<int> AllowedFloors { get; protected set; }
        public Direction Direction { get; private set; }
        public int PassengerCount { get; private set; }
        public int MaxPassengers { get; }
        public bool IsMoving => Direction != Direction.None;

        protected ElevatorBase(int id, int maxPassengers, List<int> allowedFloors)
        {
            Id = id;
            MaxPassengers = maxPassengers;
            CurrentFloor = allowedFloors[0];
            Direction = Direction.None;
            PassengerCount = 0;
            AllowedFloors = allowedFloors;
        }

        public virtual void MoveToFloor(int floor)
        {
            if (floor > CurrentFloor)
                Direction = Direction.Up;
            else if (floor < CurrentFloor)
                Direction = Direction.Down;
            else
                Direction = Direction.None;

            CurrentFloor = floor;
        }

        public bool CanAddPassengers(int passengers)
        {
            return PassengerCount + passengers <= MaxPassengers;
        }

        public void LoadPassengers(int count)
        {
            PassengerCount += count;
        }
    }
}
