FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY net/*.sln .
COPY net/Lab1/*.csproj ./net/Lab1/
COPY net/personTesting/*.csproj ./net/personTesting/
RUN dotnet restore


COPY . .
WORKDIR /app/Lab1
RUN dotnet publish -c Release -o /app/publish


# Используем образ ASP.NET Runtime 8.0 для запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Lab1.dll"]