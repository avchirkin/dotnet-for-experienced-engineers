FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Tickets.Host/Tickets.Host.csproj", "Tickets.Host/"]
COPY ["Tickets.Application.Services.Abstractions/Tickets.Application.Services.Abstractions.csproj", "Tickets.Application.Services.Abstractions/"]
COPY ["Tickets.Application.Models/Tickets.Application.Models.csproj", "Tickets.Application.Models/"]
COPY ["Tickets.Domain.Models/Tickets.Domain.Models.csproj", "Tickets.Domain.Models/"]
COPY ["Tickets.Application.Services/Tickets.Application.Services.csproj", "Tickets.Application.Services/"]
COPY ["Tickets.Persistence.Postgres/Tickets.Persistence.Postgres.csproj", "Tickets.Persistence.Postgres/"]
COPY ["Tickets.Integrations.Clients/Tickets.Integrations.Clients.csproj", "Tickets.Integrations.Clients/"]
COPY ["Tickets.Integrations.Accounts/Tickets.Integrations.Accounts.csproj", "Tickets.Integrations.Accounts/"]
COPY ["Tickets.Integrations.Tariffs/Tickets.Integrations.Tariffs.csproj", "Tickets.Integrations.Tariffs/"]
COPY ["Tickets.Api.Controllers/Tickets.Api.Controllers.csproj", "Tickets.Api.Controllers/"]
RUN dotnet restore "Tickets.Host/Tickets.Host.csproj"
COPY . .
WORKDIR "/src/Tickets.Host"
RUN dotnet build "Tickets.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Tickets.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tickets.Host.dll"]
