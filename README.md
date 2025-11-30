# 🚇 Elevator Control System API

This project is a C# ASP.NET Core Web API that simulates an elevator control system.  
It supports passenger pickup/dropoff requests and destination tracking.

---

## 📦 Prerequisites
- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/download)
- Visual Studio 2022 / Rider / VS Code (optional, for development)
- Command line access (`dotnet` CLI)

---

## ▶️ Running the API

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-org/elevator-api.git
   cd elevator-api

2. **Restore Dependencies**
  ```dotnet restore

3. **Build the project**
   ```dotnet build

4. **- Run the API on port 8080**
  ```dotnet run --urls "http://localhost:8080"

5. **Test Endpoints (ex. using curl)**
```curl
pickup
curl -X POST http://localhost:8080/api/elevators/requestPickup \
     -H "Content-Type: application/json" \
     -d '{"floor": 5, "direction": 1 }'

dropoff
curl -X POST http://localhost:8080/api/elevators/requestDropoff \
     -H "Content-Type: application/json" \
     -d '{"elevatorId": 1, "targetFloor": 10}'

get destinationss
curl http://localhost:8080/api/elevators/1/destinations

get next floor
curl http://localhost:8080/api/elevators/1/next

---

## 🌐 Using Swagger UI

This project includes Swagger/OpenAPI for interactive API testing.

1. Run the API:
   ```bash
   dotnet run --urls "http://localhost:8080"
