# Etapa de compilación (Build)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar el archivo del proyecto y restaurar las dependencias
COPY ["ApiTareas.csproj", "./"]
RUN dotnet restore "ApiTareas.csproj"

# Copiar el resto del código y compilar la aplicación
COPY . .
RUN dotnet publish "ApiTareas.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render provee el puerto dinámicamente a través de la variable de entorno PORT.
# En .NET 8 en adelante, el puerto por defecto es el 8080.
EXPOSE 8080

ENTRYPOINT ["dotnet", "ApiTareas.dll"]
