FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FightForHonorGame/FightForHonorGame.csproj", "FightForHonorGame/"]
RUN dotnet restore "FightForHonorGame/FightForHonorGame.csproj"
COPY . .
WORKDIR "/src/FightForHonorGame"
RUN dotnet build "FightForHonorGame.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FightForHonorGame.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FightForHonorGame.dll"]
