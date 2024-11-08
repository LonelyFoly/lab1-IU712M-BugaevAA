# Используем официальный образ .NET 8 SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Устанавливаем рабочую директорию
WORKDIR /src

# Копируем файл решения и восстанавливаем зависимости
COPY ["Lab1/Lab1.csproj", "Lab1/"]
RUN dotnet restore "Lab1/Lab1.csproj"

# Копируем все исходники и публикуем приложение
COPY . .
WORKDIR "/src/Lab1"
RUN dotnet publish "Lab1.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80


COPY --from=build /app/publish .

# Указываем команду для старта приложения
ENTRYPOINT ["dotnet", "Lab1.dll"]