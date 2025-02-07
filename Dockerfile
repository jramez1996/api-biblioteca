# Utiliza la imagen base de .NET Core
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Utiliza la imagen de SDK de .NET Core para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AppPromocion.WebApi/AppPromocion.WebApi.csproj", "AppPromocion.WebApi/"]
COPY ["AppPromocion.Infraestructure/AppPromocion.Infraestructure.csproj", "AppPromocion.Infraestructure/"]
COPY ["AppPromocion.Domain/AppPromocion.Domain.csproj", "AppPromocion.Domain/"]
COPY ["AppPromocion.Application/AppPromocion.Application.csproj", "AppPromocion.Application/"]
RUN dotnet restore "AppPromocion.WebApi/AppPromocion.WebApi.csproj"
COPY . .
WORKDIR "/src/AppPromocion.WebApi"
RUN dotnet build "AppPromocion.WebApi.csproj" -c Release -o /app/build

# Publica la aplicación
FROM build AS publish
RUN dotnet publish "AppPromocion.WebApi.csproj" -c Release -o /app/publish

# Agregar la carpeta de logs (si es necesario)
RUN mkdir  /app/Logs

# Configura la imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppPromocion.WebApi.dll"]