# Module 11 - DevOps and CI/CD

## What this demonstrates
A single GitHub Actions workflow (`.github/workflows/ci-cd.yml`) that
covers the full topic list for this module against the DotNet FSE +
Angular stack used throughout the program:

- **Continuous Integration** - two parallel jobs that build and test the
  backend (`dotnet restore/build/test`, publishing `.trx` test results as
  an artifact) and the frontend (`npm ci`, lint, headless Karma/Jasmine
  tests, production build) on every push and pull request
- **Continuous Delivery** - a third job (`package-artifacts`) that only
  runs on `main` once both CI jobs pass, publishes the API, and builds/
  pushes a Docker image tagged with the commit SHA to GitHub Container
  Registry - the artifact is ready to deploy, but an actual deploy step is
  left as a deliberate manual gate (a common CD vs. CD distinction)
- Job dependencies via `needs:`, conditional execution via `if:`, and
  branch-triggered workflows (`on.push.branches`)

## To run
1. Create `backend/` (an ASP.NET Core Web API project + a test project,
   e.g. from Modules 5/6/4) and `frontend/` (an Angular project, e.g. from
   Module 8) folders at the repository root, matching the paths referenced
   in the workflow.
2. Push this repository to GitHub - the workflow runs automatically from
   `.github/workflows/ci-cd.yml`; no extra setup is required beyond having
   a `GITHUB_TOKEN` (provided automatically by GitHub Actions).
3. Open the **Actions** tab on GitHub to watch the three jobs run and
   inspect the uploaded test-result artifacts.
4. Try intentionally breaking a test in either project and pushing a PR
   branch - confirm the corresponding job fails and blocks
   `package-artifacts` from running.
