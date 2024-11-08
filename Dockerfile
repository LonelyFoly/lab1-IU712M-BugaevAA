# Используем образ .NET SDK 8.0 для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /net/app

# Копируем файлы проекта и восстанавливаем зависимости
COPY *.sln .
COPY net/Lab1/*.csproj ./net/Lab1/
COPY net/personTesting/*.csproj ./net/personTesting/
RUN dotnet restore

# Копируем остальные файлы и выполняем сборку
COPY . .
WORKDIR /net/app/Lab1
RUN dotnet publish -c Release -o /net/app/publish

# Этап тестирования


# Используем образ ASP.NET Runtime 8.0 для запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /net/app
COPY --from=build /net/app/publish .
ENTRYPOINT ["dotnet", "Lab1.dll"]