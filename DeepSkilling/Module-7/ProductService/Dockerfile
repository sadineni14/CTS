# Same pattern as OrderService's Dockerfile — adjust the DLL name to match this
# service's assembly (e.g. ProductService.dll) once you copy in the Module 5/6 files.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "ProductService.dll"]
