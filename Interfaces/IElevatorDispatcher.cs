namespace ElevatorSimulation.Interfaces
{
    interface IElevatorDispatcher
    {
        void RequestElevator(int floor, int passengers);
        void ShowStatus();
    }
}
