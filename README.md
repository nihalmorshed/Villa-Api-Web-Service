# Nihal.Services.VillaApi

A RESTful API service built with ASP.NET Core for managing villa properties.

## Project Overview

This is a simple Web API project demonstrating ASP.NET Core fundamentals including:
- RESTful API design patterns
- Controller-based routing
- Data Transfer Objects (DTOs)
- Swagger/OpenAPI documentation
- HTTP status code handling

## Technology Stack

- **.NET 9.0**
- **ASP.NET Core Web API**
- **Swagger/OpenAPI** - API documentation and testing

## Project Structure

```
src/NihalMorshed.VillaApi.Services.Api/
├── Controllers/
│   └── VillaApiController.cs    # API endpoints for villa operations
├── Models/
│   └── DTOs/
│       └── VillaDto.cs          # Villa data transfer object
├── Data/
│   └── VillaStore.cs            # In-memory data store
└── Program.cs                    # Application entry point
```

## API Endpoints

### Base URL: `/api/villaApi`

| Method | Endpoint | Description | Response |
|--------|----------|-------------|----------|
| GET | `/` | Get all villas | 200 OK with villa list |
| GET | `/id?id={id}` | Get villa by ID | 200 OK, 400 Bad Request, 404 Not Found |
| POST | `/` | Create a new villa | 201 Created, 400 Bad Request, 500 Internal Server Error |

## Features

- **GET All Villas**: Retrieve a list of all available villas
- **GET Villa by ID**: Fetch a specific villa using its unique identifier
- **CREATE Villa**: Add a new villa to the collection with auto-generated ID
- **Swagger UI**: Interactive API documentation available in development mode

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later

### Running the Application

1. Clone the repository
2. Navigate to the project directory
3. Run the application:
   ```bash
   dotnet run --project src/NihalMorshed.VillaApi.Services.Api
   ```
4. Access Swagger UI at: `https://localhost:{port}/swagger`

## Development Notes

- Currently uses in-memory storage (VillaStore) for data persistence
- Configured for HTTPS redirection
- Swagger UI available only in Development environment
- Uses `CreatedAtRoute` pattern for POST responses with Location header