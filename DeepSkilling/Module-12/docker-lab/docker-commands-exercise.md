# Module 12 - Docker Commands Exercise

Work through these against the `Dockerfile` and `docker-compose.yml` in
this folder.

## Part A - Images and containers (single service)
```bash
# Build an image from the Dockerfile, tagging it
docker build -t product-service:1.0 .

# List images
docker images

# Run it in detached mode, publishing the container's port 8080 to host 8080
docker run -d --name product-api -p 8080:8080 product-service:1.0

# List running containers
docker ps

# Run it interactively instead (foreground, so you see logs directly)
docker run --rm -it -p 8081:8080 product-service:1.0

# Exec into a running container to poke around
docker exec -it product-api /bin/bash

# Stop and remove
docker stop product-api
docker rm product-api

# Remove the image
docker rmi product-service:1.0
```

## Part B - Storage
```bash
# Create a named volume explicitly
docker volume create product-data

# List all volumes
docker volume ls

# Inspect where it actually lives on the host
docker volume inspect product-data
```

## Part C - Networking
```bash
# List default networks (bridge, host, none)
docker network ls

# Create your own network (also done automatically by compose below)
docker network create deepskilling-net

# Inspect it to see which containers are attached
docker network inspect deepskilling-net
```

## Part D - Compose and orchestration basics
```bash
# Copy .env.sample to .env first, then:
docker compose up --build -d

# See both services running together
docker compose ps

# Follow logs from just the API
docker compose logs -f product-service

# Confirm service discovery: exec into the API container and ping the
# database *by service name*, not by IP - this is what "container
# orchestration" / service discovery gives you for free
docker compose exec product-service ping db -c 3

# Tear everything down (add -v to also remove the named volume)
docker compose down
```

## Questions to answer
1. What is the difference between an image and a container?
2. Why did `db` resolve by name (`ping db`) instead of needing an IP
   address inside the `product-service` container?
3. What happens to data in `sql-data` if you run `docker compose down`
   without `-v`, versus with `-v`?
4. Why would a real deployment use an orchestrator (like Kubernetes)
   instead of plain `docker compose` once you have many services and
   multiple hosts?
