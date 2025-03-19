using ElevatorSimulation.Interfaces;
using ElevatorSimulation.Models;
using ElevatorSimulation.Services;

class Program
{
    static void Main(string[] args)
    {
        List<IElevator> elevators = new List<IElevator>
        {
            new PassengerElevator(1, 5, new List<int> { 1, 2, 3, 4, 5 }),
            new PassengerElevator(2, 5, new List<int> { 3, 4, 5, 6, 7 }),
            new PassengerElevator(3, 5, new List<int> { 1, 2, 3 })
        };

        IElevatorDispatcher dispatcher = new ElevatorDispatcher(elevators);

        while (true)
        {
            Console.WriteLine("\n1. Call Elevator\n2. View Elevator Status\n3. Exit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            if (input == "3")
                break;

            else if (input == "1")
            {
                Console.Write("Enter floor number: ");
                int floor = int.Parse(Console.ReadLine());

                Console.Write("Enter number of passengers: ");
                int passengers = int.Parse(Console.ReadLine());

                dispatcher.RequestElevator(floor, passengers);
            }
            else if (input == "2")
            {
                dispatcher.ShowStatus();
            }
            else
            {
                Console.WriteLine("Unknown command.");
            }
        }
    }
}