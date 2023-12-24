# Base image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

# Copy csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RestfulApiExample/RestfulApiExample.csproj", "RestfulApiExample/"]
RUN dotnet restore "RestfulApiExample/RestfulApiExample.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/RestfulApiExample"
RUN dotnet build "RestfulApiExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RestfulApiExample.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestfulApiExample.dll"]