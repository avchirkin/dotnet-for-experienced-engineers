FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Accounts.Host/Accounts.Host.csproj", "Accounts.Host/"]
COPY ["Accounts.Persistence.Postgres/Accounts.Persistence.Postgres.csproj", "Accounts.Persistence.Postgres/"]
COPY ["Accounts.Domain.Models/Accounts.Domain.Models.csproj", "Accounts.Domain.Models/"]
COPY ["Accounts.Application.Services.Abstractions/Accounts.Application.Services.Abstractions.csproj", "Accounts.Application.Services.Abstractions/"]
COPY ["Accounts.Application.Models/Accounts.Application.Models.csproj", "Accounts.Application.Models/"]
COPY ["Accounts.Application.Services/Accounts.Application.Services.csproj", "Accounts.Application.Services/"]
COPY ["Accounts.Api.Controllers/Accounts.Api.Controllers.csproj", "Accounts.Api.Controllers/"]
RUN dotnet restore "Accounts.Host/Accounts.Host.csproj"
COPY . .
WORKDIR "/src/Accounts.Host"
RUN dotnet build "Accounts.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Accounts.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Accounts.Host.dll"]
