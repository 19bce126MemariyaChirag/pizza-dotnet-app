# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-stage
# ENV ASPNETCORE_URLS=http://+:80
# WORKDIR /app
# COPY . ./
# EXPOSE 80
# ENTRYPOINT ["dotnet", "./PizzaApi.dll"]

# # Use the official .NET Core SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# # Set the working directory to /app
WORKDIR /app

# Copy the csproj file and restore any dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code and build the app
COPY . ./
RUN dotnet publish -c Release -o out

# Create a new image from the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expose port 80 for the app to listen on
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "PizzaApi.dll"]

