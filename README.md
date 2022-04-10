# HeraCleanArchitecture
## Technologies
* [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Entity Framework Core 6](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* SQL server
## Getting Started

* Install the latest [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
* Install SQL server (https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

* dotnet build
* dotnet run --project hera.webapi
* Open swagger by access link https://localhost:7157/

### Database Migrations

* Migration EF core (https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
    * cd src
    * (Not existing DB) dotnet ef migrations -s hera.webapi -p hera.infrastructure  add InitialCreate
    * dotnet ef -s hera.webapi -p hera.infrastructure database update


To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

* `--project src/hera.infrastructure` (optional if in this folder)
* `--startup-project src/hera.webapi`
* `--output-dir src/Infrastructure/Persistence/Migrations`
## Docker configuration

* Build docker `docker build -f "Hera.WebApi\Dockerfile" -r heraapi .`
* Run docker ` docker  run -p 8080:80 -d heraapi` 