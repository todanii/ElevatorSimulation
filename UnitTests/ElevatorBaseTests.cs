using ElevatorSimulation.Models;
using ElevatorSimulation.Enums;

namespace UnitTests
{
    public class ElevatorBaseTests
    {
        private class TestElevator : ElevatorBase
        {
            public TestElevator(int id, int maxPassengers, List<int> allowedFloors)
                : base(id, maxPassengers, allowedFloors) { }
        }

        private TestElevator _elevator;

        public ElevatorBaseTests()
        {
            _elevator = new TestElevator(1, 10, new List<int> { 1, 2, 3, 4, 5 });
        }

        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            Assert.Equal(1, _elevator.Id);
            Assert.Equal(10, _elevator.MaxPassengers);
            Assert.Equal(1, _elevator.CurrentFloor);
            Assert.Equal(Direction.None, _elevator.Direction);
            Assert.Equal(0, _elevator.PassengerCount);
            Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, _elevator.AllowedFloors);
        }

        [Fact]
        public void MoveToFloor_UpdatesCurrentFloorAndDirection()
        {
            _elevator.MoveToFloor(3);
            Assert.Equal(3, _elevator.CurrentFloor);
            Assert.Equal(Direction.Up, _elevator.Direction);

            _elevator.MoveToFloor(1);
            Assert.Equal(1, _elevator.CurrentFloor);
            Assert.Equal(Direction.Down, _elevator.Direction);

            _elevator.MoveToFloor(1);
            Assert.Equal(1, _elevator.CurrentFloor);
            Assert.Equal(Direction.None, _elevator.Direction);
        }

        [Fact]
        public void CanAddPassengers_ReturnsCorrectValue()
        {
            Assert.True(_elevator.CanAddPassengers(5));
            Assert.False(_elevator.CanAddPassengers(11));
        }

        [Fact]
        public void LoadPassengers_IncreasesPassengerCount()
        {
            _elevator.LoadPassengers(5);
            Assert.Equal(5, _elevator.PassengerCount);

            _elevator.LoadPassengers(3);
            Assert.Equal(8, _elevator.PassengerCount);
        }
    }
}
