# ClientServer-gRPC

A sample gRPC project demonstrating both **server** and **client** implementations in a single solution.  
This project showcases a typical layered architecture with **EF Core**, **Manual Mapping**, **Projections**, **Minimal APIs**, **Interceptors** for error handling, and usage of **grpcui**.  

## Table of Contents
1. [Overview](#overview)
2. [Features](#features)
3. [Technologies](#technologies)
4. [Architecture](#architecture)
5. [Setup & Installation](#setup--installation)
6. [Running the Application](#running-the-application)
7. [Usage & Testing](#usage--testing)
8. [Project Structure](#project-structure)
9. [Contributing](#contributing)
10. [License](#license)

---

## Overview
In **real-world projects**, you often either **provide** a gRPC service or **consume** one—but rarely both at the same time in the same codebase.  
This sample project, **ClientServer-gRPC**, demonstrates how to:
- Implement a **gRPC service** (server) offering CRUD operations on a `Student` entity.
- Implement a **client** that consumes those gRPC services and provides CRUD functionality via **Razor Pages**.

---

## Features
- **.NET 8** application for both Server and Client.
- **Entity Framework Core (EF Core)** for data access on the **server** side.
- **Manual mapping & projection** to reduce unnecessary database calls.
- **Interceptors** for centralizing error handling in gRPC services.
- **Minimal APIs** approach for simpler service definitions.
- A **protofile provider** pattern to handle `.proto` files effectively.
- **grpcui** support to interactively test and explore the gRPC endpoints.
- Layered architecture for **Business Logic (BLL)**, **Data Access (DAL)**, **Domain** models, and **GRPC** (Web).

---

## Technologies
- **C# .NET 8**
- **gRPC** (Google Remote Procedure Call)
- **Razor Pages** (client UI)
- **EF Core** for database operations
- **SQL Server** database
- **grpcui** for testing

---

## Architecture
The solution is split into multiple layers/projects for both the **service** and **client**:

1. **DAL (Data Access Layer)**  
   - **Server-side**: Communicates with the database using EF Core.  
   - **Client-side**: Calls the server’s gRPC endpoints (instead of a database).

2. **BLL (Business Logic Layer)**  
   - Handles core application logic, validations, and orchestration of data.

3. **Domain**  
   - Contains entities like `Student` and possibly related domain logic or value objects.

4. **GRPC/Web**  
   - **Server**: Hosts the gRPC services (including `.proto` files, minimal APIs, interceptors).  
   - **Client**: Contains the gRPC client stubs and Razor Pages for the UI.

---

## Setup & Installation

1. **Clone the Repository**  
   - Run the following commands:
    
        git clone https://github.com/Hemmatiali/ClientServer-gRPC.git
        cd ClientServer-gRPC

2. **Install .NET 8 SDK (if not already installed)**  
   - [Download .NET 8 SDK](https://dotnet.microsoft.com/en-us/download)

3. **Restore NuGet Packages**  
   - From the project root, run:
    
        dotnet restore

4. **Set up Database (Server-Side)**  
   - Ensure your database connection string is correct in the server’s `appsettings.json` (or equivalent).
   - Run Entity Framework migrations (if applicable):
    
        cd ServiceProject
        dotnet ef database update

## Running the Application

1. **Start the gRPC Server**  
   - Navigate to the server project and run:
    
        cd ServiceProject
        dotnet run

   - This will launch the service, hosting gRPC endpoints.

2. **Start the Client**  
   - In a separate terminal, navigate to the client project and run:
    
        cd ClientProject
        dotnet run

   - This will launch the Razor Pages application that consumes the gRPC services.

## Usage & Testing

### Razor Pages (Client-Side)
- Open the client application in your browser (commonly `https://localhost:5001` or similar).
- Perform CRUD operations for **Student** entities via the UI forms.

### grpcui
- With the service running, install and run `grpcui` to explore the endpoints:
    
        grpcui -plaintext localhost:PORT

  - Replace **PORT** with the gRPC server port (e.g., 5000).
  - You can call the service methods interactively, view request/response schemas, etc.

### Interceptors
- Any server-side exceptions or validations will be handled by the configured interceptor, returning structured error responses.

## Project Structure

    ClientServer-gRPC/
    ├── src/
    │   ├── Domain/
    │   │   └── Entities (Student.cs, etc.)
    │   ├── BLL/
    │   ├── DAL/
    │   │   └── EF Core DbContext, Migrations, Repositories, etc.
    │   ├── GRPC/
    │   │   ├── Protos (student.proto, etc.)
    │   │   ├── Services (StudentService.cs, etc.)
    │   │   ├── Interceptors
    │   │   └── Program.cs (Minimal APIs, gRPC hosting)
    │   └── appsettings.json
    ├── srcClient/
    │   ├── Domain/ (Shared models if needed)
    │   ├── BLL/
    │   ├── DAL/
    │   │   └── gRPC Clients (generated from .proto)
    │   ├── GRPC/
    │   │   ├── Razor Pages (CRUD forms for Student)
    │   │   └── Program.cs (Client hosting)
    └── README.md

## Contributing
1. Fork the repo
2. Create a new branch for your feature/bugfix
3. Commit and push
4. Open a Pull Request

## License
This project is licensed under the **MIT License**. Feel free to use and modify as needed for your own projects.
