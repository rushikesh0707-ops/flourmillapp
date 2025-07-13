# Use official .NET 8 SDK image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY ["FlourmillAPI/FlourmillAPI.csproj", "FlourmillAPI/"]
RUN dotnet restore "FlourmillAPI/FlourmillAPI.csproj"

# Copy rest of app
COPY . .
WORKDIR "/src/FlourmillAPI"
RUN dotnet build "FlourmillAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlourmillAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlourmillAPI.dll"]
