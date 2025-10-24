# BrasilApiConsumer

A .NET 8.0 Web API that provides a clean, validated, and well-documented interface to [Brasil API](https://brasilapi.com.br) - a free public API offering various Brazilian data services.

## Overview

BrasilApiConsumer acts as a wrapper/proxy service for Brasil API, adding enterprise-grade features such as:
- Input validation and sanitization
- Structured logging
- Centralized error handling
- Interactive API documentation (Swagger/OpenAPI)
- Type-safe HTTP client implementation using Refit

## Available Endpoints

The API provides access to the following Brazilian data services:

### Financial Services
- **Banks** (`/banks`) - List all Brazilian banks or lookup by code
- **Cambio** (`/cambio`) - Currency exchange rates and available currencies
- **Corretoras** (`/corretoras`) - Stock brokerage firms registered with CVM (Comissão de Valores Mobiliários)
- **Taxas** (`/taxas`) - Brazilian tax rates (Selic, CDI, IPCA, etc.)

### Address & Location
- **CEP** (`/cep`) - Brazilian postal code lookup with full address information
- **DDD** (`/ddd`) - Area code information and associated cities

### Business & Legal
- **CNPJ** (`/cnpj`) - Company registration data lookup
- **Registro.br** (`/registrobr`) - Brazilian domain registration information

### Payment & Dates
- **PIX** (`/pix`) - PIX payment system participants
- **Feriados** (`/feriados`) - Brazilian national holidays by year

## Technology Stack

- **.NET 8.0** - Latest LTS version of .NET
- **Refit 8.0** - Type-safe REST library for .NET
- **Swashbuckle/Swagger** - API documentation and testing interface
- **ASP.NET Core** - Web API framework

## Getting Started

### Prerequisites
- .NET 8.0 SDK or later

### Running the Application

1. Clone the repository
2. Navigate to the project directory
3. Run the application:
   ```bash
   dotnet run
   ```
4. Access the Swagger UI at `https://localhost:{port}/swagger` (in development mode)

### Building the Project

```bash
dotnet build
```

### Running Tests

```bash
dotnet test
```

## Features

### Input Validation
All endpoints include comprehensive input validation to ensure data integrity and prevent invalid requests to the upstream Brasil API.

### Logging
Structured logging is implemented across all controllers, providing visibility into:
- Request processing
- Successful operations
- Warning conditions
- Error scenarios

### Error Handling
Custom middleware (`RefitExceptionMiddleware`) provides centralized exception handling for all Refit HTTP client operations, ensuring consistent error responses.

### API Documentation
Interactive Swagger/OpenAPI documentation is available in development mode, allowing developers to:
- Explore all available endpoints
- View request/response schemas
- Test API calls directly from the browser

## Project Structure

```
BrasilApiConsumer/
├── Controllers/        # API endpoint controllers
├── Models/            # Data models and DTOs
├── Services/          # Service interfaces (IBrasilApi)
├── Middleware/        # Custom middleware (error handling)
├── Extensions/        # Extension methods
├── Enums/            # Enumerations (e.g., CurrencyCode)
└── Converters/       # JSON converters
```

## Configuration

The application is configured to:
- Use lowercase URLs for consistency
- Serialize enums as strings in JSON responses
- Redirect HTTP to HTTPS
- Use Brasil API base URL: `https://brasilapi.com.br/api`

## Contributing

Contributions are welcome! Please feel free to submit issues or pull requests.

## License

This project is provided as-is for educational and commercial purposes.

## Acknowledgments

This project consumes data from [Brasil API](https://brasilapi.com.br), a free and open initiative to provide access to Brazilian public data.
