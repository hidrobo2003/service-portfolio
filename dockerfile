# 1. Etapa de compilación (SDK)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copiar archivos del proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del código y compilar
COPY . ./
RUN dotnet publish -c Release -o out

# 2. Etapa de ejecución (Runtime - mucho más ligera)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Exponer el puerto de la app
EXPOSE 8080

# Comando para arrancar la API
ENTRYPOINT ["dotnet", "ProjectsQueryAPI.dll"]
