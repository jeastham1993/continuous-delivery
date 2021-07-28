# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./src/JEasthamDev.Api/JEasthamDev.Api.csproj ./src/JEasthamDev.Api/JEasthamDev.Api.csproj
RUN dotnet restore ./src/JEasthamDev.Api/JEasthamDev.Api.csproj

# Copy everything else and build
COPY ./src/ ./src/
RUN dotnet publish ./src/JEasthamDev.Api/JEasthamDev.Api.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "JEasthamDev.Api.dll"]