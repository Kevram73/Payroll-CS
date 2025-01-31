# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy and restore dependencies
COPY ["Payroll.csproj", "./"]
RUN dotnet restore "./Payroll.csproj"

# Copy source and publish
COPY . .
RUN dotnet publish "Payroll.csproj" -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published app from build stage
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Set entrypoint
ENTRYPOINT ["dotnet", "Payroll.dll"]
