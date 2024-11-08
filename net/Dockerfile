# Используем образ .NET SDK 8.0 для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Копируем файлы проекта и восстанавливаем зависимости
COPY *.sln .
COPY Lab1/*.csproj ./Lab1/
COPY personTesting/*.csproj ./personTesting/
RUN dotnet restore

# Копируем остальные файлы и выполняем сборку
COPY . .
WORKDIR /app/Lab1
RUN dotnet publish -c Release -o /app/publish

# Этап тестирования


# Используем образ ASP.NET Runtime 8.0 для запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Lab1.dll"]