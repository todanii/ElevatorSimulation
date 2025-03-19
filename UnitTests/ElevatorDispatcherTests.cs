using ElevatorSimulation.Enums;
using ElevatorSimulation.Interfaces;
using ElevatorSimulation.Services;
using Moq;

namespace UnitTests
{

    public class ElevatorDispatcherTests
    {
        [Fact]
        public void RequestElevator_NoAvailableElevator_ShouldShowMessage()
        {
            // Arrange
            var mockElevator = new Mock<IElevator>();
            mockElevator.Setup(e => e.IsMoving).Returns(false);
            mockElevator.Setup(e => e.CanAddPassengers(It.IsAny<int>())).Returns(false);
            var elevators = new List<IElevator> { mockElevator.Object };
            var dispatcher = new ElevatorDispatcher(elevators);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                dispatcher.RequestElevator(1, 1);
                var result = sw.ToString().Trim();

                // Assert
                Assert.Equal("No available elevator. Please wait.", result);
            }
        }

        [Fact]
        public void RequestElevator_AvailableElevator_ShouldMoveAndLoadPassengers()
        {
            // Arrange
            var mockElevator = new Mock<IElevator>();
            mockElevator.Setup(e => e.IsMoving).Returns(false);
            mockElevator.Setup(e => e.CanAddPassengers(It.IsAny<int>())).Returns(true);
            mockElevator.Setup(e => e.AllowedFloors).Returns(new List<int> { 1 });
            mockElevator.Setup(e => e.CurrentFloor).Returns(0);
            var elevators = new List<IElevator> { mockElevator.Object };
            var dispatcher = new ElevatorDispatcher(elevators);

            // Act
            dispatcher.RequestElevator(1, 1);

            // Assert
            mockElevator.Verify(e => e.MoveToFloor(1), Times.Once);
            mockElevator.Verify(e => e.LoadPassengers(1), Times.Once);
        }

        [Fact]
        public void ShowStatus_ShouldDisplayElevatorStatus()
        {
            // Arrange
            var mockElevator = new Mock<IElevator>();
            mockElevator.Setup(e => e.Id).Returns(1);
            mockElevator.Setup(e => e.CurrentFloor).Returns(0);
            mockElevator.Setup(e => e.Direction).Returns(Direction.None);
            mockElevator.Setup(e => e.PassengerCount).Returns(0);
            mockElevator.Setup(e => e.MaxPassengers).Returns(10);
            var elevators = new List<IElevator> { mockElevator.Object };
            var dispatcher = new ElevatorDispatcher(elevators);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                dispatcher.ShowStatus();
                var result = sw.ToString().Trim();

                // Assert
                Assert.Equal("Elevator 1 - Floor: 0, Direction: None, Passengers:  0/10", result);
            }
        }
    }

}
