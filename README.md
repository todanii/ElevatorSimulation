# Elevator Simulation

## Overview
This project simulates an elevator system with multiple elevators. It allows users to call an elevator to a specific floor and view the status of all elevators.

## Features
- Multiple elevators with different floor ranges.
- Request an elevator to a specific floor with a specified number of passengers.
- View the status of all elevators.

## Project Structure
- **Interfaces**: Contains the `IElevator` and `IElevatorDispatcher` interfaces.
- **Models**: Contains the `PassengerElevator` class which implements the `IElevator` interface.
- **Services**: Contains the `ElevatorDispatcher` class which implements the `IElevatorDispatcher` interface.
- **Program.cs**: The main entry point of the application.

## Getting Started
### Prerequisites
- .NET 8.0 SDK or later

### Running the Application
1. Clone the repository.
2. Navigate to the project directory.
3. Run the following command to start the application:
### Usage
1. When prompted, choose an option:
   - `1. Call Elevator`: Request an elevator to a specific floor.
   - `2. View Elevator Status`: View the current status of all elevators.
   - `3. Exit`: Exit the application.
2. Follow the prompts to enter the floor number and the number of passengers when calling an elevator.
