# C# WPF Chat Program

This repository contains a C# WPF-based chat program consisting of a client and server application. The program allows multiple clients to connect to a central server and communicate with each other via messages, with optional login requirements.

## Features

### Completed Requirements
1. **Basic Connection and Messaging (Requirement 2)**
   - Clients can connect to the server without issues.
   - Clients can send messages to each other, including messages with accented characters.
   - Proper socket disconnection is handled, allowing clients to disconnect without causing issues for other connected clients.

2. **User Authentication (Requirement 3)**
   - Upon connecting to the server, clients must provide login information, specifically a username and password.
   - Login information management (creation, storage, and maintenance) has been implemented.

### Future Enhancements
This application currently satisfies the requirements up to level 3. Additional features that may be implemented include:
- **Private Messaging (Requirement 4)**: Enabling clients to send private messages to specific users.
- **File Transfer or Real-Time Communication (Requirement 5)**: Allowing clients to transfer files or engage in real-time communication (e.g., video chat).

## Getting Started

### Prerequisites
- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework)
- Visual Studio or another C# compatible IDE

### Installation
1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/Ilonczai-Andras/Chat-application
2. Open the solution in Visual Studio.

3. Build the solution to restore dependencies and prepare the application for running.

### Running the Application
1. Start the server application.
2. Run one or more client applications to connect to the server.
    For each client, provide the required login credentials.
### Usage:
- Clients can communicate by sending messages to all connected clients.
- Clients can disconnect gracefully from the server.
