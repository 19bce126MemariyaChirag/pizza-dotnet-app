FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-stage
ENV ASPNETCORE_URLS=http://+:80
WORKDIR /app
COPY . ./
EXPOSE 80
ENTRYPOINT ["dotnet", "./PizzaApi.dll"]