FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Migrations/Migrations/Migrations.csproj", "Migrations/Migrations/"]
RUN dotnet restore "Migrations/Migrations/Migrations.csproj"
COPY . .
WORKDIR "/src/Migrations/Migrations"
RUN dotnet build "Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Migrations.dll"]
