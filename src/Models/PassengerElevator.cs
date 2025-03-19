namespace ElevatorSimulation.Models
{
    public class PassengerElevator : ElevatorBase
    {
        public PassengerElevator(int id, int capacity, List<int> allowedFloors) : base(id, capacity, allowedFloors) { }
    }
}
