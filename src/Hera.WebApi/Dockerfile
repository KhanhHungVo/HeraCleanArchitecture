#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Hera.WebApi/Hera.WebApi.csproj", "src/Hera.WebApi/"]
COPY ["src/Hera.Infrastructure/Hera.Infrastructure.csproj", "src/Hera.Infrastructure/"]
COPY ["src/Hera.Domain/Hera.Domain.csproj", "src/Hera.Domain/"]
COPY ["src/Hera.Application/Hera.Application.csproj", "src/Hera.Application/"]
RUN dotnet restore "src/Hera.WebApi/Hera.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Hera.WebApi"
RUN dotnet build "Hera.WebApi.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS migration
WORKDIR /src
COPY . .
WORKDIR /src/Hera.Migration
RUN dotnet build "Hera.Migration/csproj" -c Release -o /app/migration

FROM build AS publish
RUN dotnet publish "Hera.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /migration
COPY --from=migration /app/migration .

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hera.WebApi.dll"]