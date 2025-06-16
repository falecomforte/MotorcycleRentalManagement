# Motorcycle Rental Management Application

## Overview
The Motorcycle Rental Management application is designed to facilitate the rental process of motorcycles. It provides a RESTful API for managing motorcycle rentals, utilizing MongoDB for data storage and RabbitMQ for messaging.

## Features
- Create, read, update, and delete motorcycle records.
- Manage motorcycle rentals with business logic for renting and returning motorcycles.
- Publish events to RabbitMQ for asynchronous processing.

## Project Structure
```
MotorcycleRentalManagement
├── src
│   ├── MotorcycleRentalManagement.Api          # API layer
│   ├── MotorcycleRentalManagement.Application     # Application layer
│   ├── MotorcycleRentalManagement.Domain          # Domain layer
│   ├── MotorcycleRentalManagement.Infrastructure   # Infrastructure layer
│   └── MotorcycleRentalManagement.Contracts       # Contracts for data transfer
├── tests                                         # Unit tests
└── MotorcycleRentalManagement.sln                # Solution file
```

## Setup Instructions
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd MotorcycleRentalManagement
   ```
3. Restore the dependencies:
   ```
   dotnet restore
   ```
4. Configure the `appsettings.json` file with your MongoDB connection string and RabbitMQ settings.
5. Run the application:
   ```
   dotnet run --project src/MotorcycleRentalManagement.Api
   ```

## Usage
- The API can be accessed at `http://localhost:5000`.
- Use tools like Postman or Swagger UI to interact with the API endpoints.

## API Endpoints
- `POST /motorcycles` - Create a new motorcycle
- `GET /motorcycles` - Retrieve all motorcycles
- `PUT /motorcycles/{id}` - Update an existing motorcycle
- `DELETE /motorcycles/{id}` - Delete a motorcycle

## Testing
To run the unit tests, navigate to the `tests` directory and execute:
```
dotnet test
```

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License.