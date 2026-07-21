# Consuming SOAP Services in ASP.NET Core

Modern .NET (Core/5+/8) has no built-in SOAP client generation like classic WCF did in
.NET Framework, but you can still consume SOAP/WSDL services in two common ways:

## Option A — dotnet-svcutil (closest to old "Add Service Reference")
```
dotnet tool install --global dotnet-svcutil
dotnet svcutil https://example.com/SomeService.svc?wsdl
```
This generates a `ServiceReference` folder with client proxy classes you call like normal C#
methods — see `GeneratedClientUsageExample.cs` below for the calling pattern it produces.

## Option B — CoreWCF (for CREATING/hosting a SOAP service in modern .NET, if needed)
Add the `CoreWCF.Primitives`, `CoreWCF.Http`, and `CoreWCF.WSDL` NuGet packages, then
configure a service contract + endpoint similarly to classic WCF `ServiceHost` setup.
See `SoapWeatherService.cs` for a minimal example contract/service pair.
