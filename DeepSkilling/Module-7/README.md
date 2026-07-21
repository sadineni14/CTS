# Module 7 - Microservices Architecture using ASP.NET Core Web API

## What this demonstrates
- Two independently deployable services: **ProductService** (Module 6/5) and **OrderService**
- Inter-service communication over HTTP using a typed `HttpClient` (`ProductClient`)
- OrderService validates a product exists in ProductService before creating an order —
  a simple example of data consistency across service boundaries
- Each service has its own `Program.cs`, own port, and its own configuration
  (`ProductServiceUrl` in OrderService's `appsettings.json` is the basic form of service
  discovery/location used here)

This module now also demonstrates:
- A `/health` endpoint on OrderService (`MapHealthChecks`) — the monitoring/health-check
  sub-topic
- Basic console logging setup in OrderService's `Program.cs`
- `Dockerfile` for each service, and a root `docker-compose.yml` that builds and runs both
  together with correct inter-service networking (services reach each other by container name,
  e.g. `http://productservice:8080`) — the Docker/Kubernetes automation sub-topic
- A sample GitHub Actions pipeline (`.github/workflows/ci-cd.yml`) that restores, builds, and
  tests both services — the CI/CD sub-topic

## To run
1. Set up `ProductService/` using Module 6 + Module 5 files, run it on port 5001.
2. Set up `OrderService/` (already scaffolded here), run it on port 5002.
3. Update `OrderService/appsettings.json`'s `ProductServiceUrl` to match ProductService's
   actual URL.
4. POST to OrderService's `/api/orders` with a valid `productId` — it will call ProductService
   internally to validate before creating the order.
5. Check `GET http://localhost:5002/health` to see the health check response.
6. To run both services together with Docker: `docker compose up --build` from this folder
   (after copying the Module 5/6 files into `ProductService/`).
