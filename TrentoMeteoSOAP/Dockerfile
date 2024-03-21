#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TrentoMeteoSOAP/TrentoMeteoSOAP.csproj", "TrentoMeteoSOAP/"]
RUN dotnet restore "./TrentoMeteoSOAP/./TrentoMeteoSOAP.csproj"
COPY . .
WORKDIR "/src/TrentoMeteoSOAP"
RUN dotnet build "./TrentoMeteoSOAP.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TrentoMeteoSOAP.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrentoMeteoSOAP.dll"]
ENV ASPNETCORE_URLS="http://0.0.0.0:8080"