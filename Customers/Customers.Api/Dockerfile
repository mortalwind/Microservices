#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Customers/Customers.Api/Customers.Api.csproj", "Customers/Customers.Api/"]
COPY ["Customers/Customers.Services/Customers.Services.csproj", "Customers/Customers.Services/"]
COPY ["Customers/Customers.Infrastructure/Customers.Infrastructure.csproj", "Customers/Customers.Infrastructure/"]
COPY ["Customers/Customers.Models/Customers.Models.csproj", "Customers/Customers.Models/"]
RUN dotnet restore "Customers/Customers.Api/Customers.Api.csproj"
COPY . .
WORKDIR "/src/Customers/Customers.Api"
RUN dotnet build "Customers.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customers.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customers.Api.dll"]
