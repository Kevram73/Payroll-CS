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
FROM nginx:alpine
WORKDIR /usr/share/nginx/html

# Remove default nginx config and copy custom one
RUN rm /etc/nginx/conf.d/default.conf
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Copy ASP.NET Core output to NGINX directory
COPY --from=build /app/publish /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
