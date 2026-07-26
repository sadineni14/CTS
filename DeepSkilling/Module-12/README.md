# Module 12 - Containerization using Docker

## What this demonstrates
- `docker-lab/Dockerfile` - a multi-stage build for the ASP.NET Core API
  (Module 5/6/7), keeping the final runtime image slim by separating the
  SDK build stage from the ASP.NET runtime stage
- `docker-lab/docker-compose.yml` - two services (the API and a SQL Server
  container) on a custom bridge network, with a named volume for
  persistent SQL storage and environment-variable based configuration -
  covering the Docker Storage, Networking, and orchestration-basics
  sub-topics
- `docker-lab/docker-commands-exercise.md` - a hands-on walkthrough of the
  core Docker CLI (`build`, `run`, `ps`, `exec`, `stop`, `rm`, `rmi`),
  volumes (`docker volume create/ls/inspect`), networks (`docker network
  create/ls/inspect`), and Compose (`up`, `ps`, `logs`, `exec`, `down`)

## To run
1. Copy the `ProductService` project (from Module 6/7) into this folder so
   `Dockerfile` finds `*.csproj` alongside it, or adjust the `COPY`/`WORKDIR`
   paths to point at wherever your API project lives.
2. Copy `.env.sample` to `.env` and set a real password.
3. Work through `docker-commands-exercise.md` in order, Part A through D.
4. Answer the questions at the end of the exercise file before moving to
   Module 13.
