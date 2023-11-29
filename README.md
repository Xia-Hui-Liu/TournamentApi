# TournamentApi

TournamentApi is a web API built with ASP.NET Core (.NET 8) that utilizes Entity Framework Core for database interaction. It works with SQL Server and employs service injection and AutoMapper. The project is structured with three main components: Tournament.Api, Tournament.Core (class library), and Tournament.Data (class library).

## Features

- ASP.NET Core Web API
- .NET 8
- Entity Framework Core
- SQL Server
- Dependency Injection
- AutoMapper

## Project Structure

- **Tournament.Api:** The main web API project.
- **Tournament.Core:** Class library containing core entities and DTOs.
- **Tournament.Data:** Class library handling data access and database interactions.

## Prerequisites

Before you begin, ensure you have the following installed:

- .NET 8 SDK
- SQL Server (and connection details configured)

## Getting Started

1. Clone the repository: `git clone https://github.com/yourusername/TournamentApi.git`
2. Navigate to the project directory: `cd TournamentApi`
3. Build the solution: `dotnet build`
4. Update the database connection string in `appsettings.json` of Tournament.Api.
5. Apply migrations to create the database: `dotnet ef database update`
6. Run the application: `dotnet run`

The API will be accessible at `https://localhost:5001` by default.

## Usage

- Make requests to the API endpoints using your preferred tool (e.g., Postman, curl).
- Explore and modify the code in `Tournament.Api`, `Tournament.Core`, and `Tournament.Data` based on your project requirements.


