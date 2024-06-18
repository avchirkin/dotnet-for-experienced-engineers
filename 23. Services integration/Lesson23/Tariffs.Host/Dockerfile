FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Tariffs.Host/Tariffs.Host.csproj", "Tariffs.Host/"]
COPY ["Tariffs.Application.Services.Abstractions/Tariffs.Application.Services.Abstractions.csproj", "Tariffs.Application.Services.Abstractions/"]
COPY ["Tariffs.Application.Models/Tariffs.Application.Models.csproj", "Tariffs.Application.Models/"]
COPY ["Tariffs.Domain.Models/Tariffs.Domain.Models.csproj", "Tariffs.Domain.Models/"]
COPY ["Tariffs.Application.Services/Tariffs.Application.Services.csproj", "Tariffs.Application.Services/"]
COPY ["Tariffs.Persistence.Postgres/Tariffs.Persistence.Postgres.csproj", "Tariffs.Persistence.Postgres/"]
COPY ["Tariffs.Api.Controllers/Tariffs.Api.Controllers.csproj", "Tariffs.Api.Controllers/"]
RUN dotnet restore "Tariffs.Host/Tariffs.Host.csproj"
COPY . .
WORKDIR "/src/Tariffs.Host"
RUN dotnet build "Tariffs.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Tariffs.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tariffs.Host.dll"]
