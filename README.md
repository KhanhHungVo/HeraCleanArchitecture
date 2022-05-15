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
* For Mac M1 using docker (https://database.guide/how-to-install-sql-server-on-an-m1-mac-arm64/)

* `dotnet dev-certs https --trust`
* `dotnet build`
* `dotnet run --project src/hera.webapi`
* Open swagger by access link https://localhost:7157/

### Database Migrations

* Migration EF core 
    * How to install, manage migrations (https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
    * Cmd reference (https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
    * apply new migration `dotnet ef migrations -s src/hera.webapi -p src/hera.infrastructure  add InitialCreate`
    * create or update db `dotnet ef -s src/hera.webapi -p src/hera.infrastructure database update`


To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

* `--project src/hera.infrastructure` (optional if in this folder)
* `--startup-project src/hera.webapi`
* `--output-dir src/Infrastructure/Persistence/Migrations`
## Docker configuration

* Build docker `docker build -f "src\Hera.WebApi\Dockerfile" -t heraapi .`
* Run docker `docker  run -p 8080:80 -d heraapi` 

* Run docker compose 
    * Docker compose with https (https://docs.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-6.0)
       - Windows using linux container `dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p { password here }`
       - Mac or Linux  `dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p { password here }`
       - `dotnet dev-certs https --trust`
    * Start the container `docker-compose -f "docker-compose.yaml" up -d`