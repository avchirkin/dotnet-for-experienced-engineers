FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Clients.Host/Clients.Host.csproj", "Clients.Host/"]
COPY ["Clients.Application.Services/Clients.Application.Services.csproj", "Clients.Application.Services/"]
COPY ["Clients.Domain.Models/Clients.Domain.Models.csproj", "Clients.Domain.Models/"]
COPY ["Clients.Application.Models/Clients.Application.Models.csproj", "Clients.Application.Models/"]
COPY ["Clients.Persistence.Postgres/Clients.Persistence.Postgres.csproj", "Clients.Persistence.Postgres/"]
COPY ["Clients.Application.Services.Abstractions/Clients.Application.Services.Abstractions.csproj", "Clients.Application.Services.Abstractions/"]
COPY ["Clients.Api.Controllers/Clients.Api.Controllers.csproj", "Clients.Api.Controllers/"]
RUN dotnet restore "Clients.Host/Clients.Host.csproj"
COPY . .
WORKDIR "/src/Clients.Host"
RUN dotnet build "Clients.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Clients.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clients.Host.dll"]
