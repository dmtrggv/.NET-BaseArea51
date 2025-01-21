# Base Area 51  

A console-based simulation of a secure elevator system in a classified facility. This project demonstrates C# programming, multithreading, and user interaction by simulating agents with different security clearances navigating various floors.

## About the Project  

The Elevator Simulation System allows users to simulate the movement of agents with varying clearance levels across secure floors of a base. Each agent is governed by specific security rules that determine which floors they can access. The elevator operates realistically, handling floor-to-floor movement and validating access at each level.

### Key Features  

- **Agent Management**: Agents have unique names, clearance levels, and current locations.
  - **Confidential**: Access to Ground floor only.
  - **Secret**: Access to Ground and Secret floors.
  - **Top-Secret**: Full access to all floors.
- **Interactive Gameplay**: Users select agents and assign target floors in a console-based interface.
- **Elevator Simulation**:
  - Realistic 1-second-per-floor movement.
  - Access validation for each floor.
  - Feedback on failed attempts and accessible floors after three denied entries.
- **Multithreading**: Each agent operates on a separate thread for concurrent interactions.

## Technologies Used  

- **Language**: C#  
- **Framework**: .NET 6
- **Multithreading**: System.Threading for concurrency.  
- **Task Management**: Async/await for elevator operations.  

## How to Run  

1. Clone the repository:  
   ```bash
   git clone https://github.com/your-username/.NET-BaseArea51.git
   cd elevator-simulation
