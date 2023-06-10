# Set the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory inside the container
WORKDIR /library

# Copy csproj and restore as distinct layers
COPY library/Library.WebUI/Library.WebUI.csproj .
COPY library/Library.Contracts/Library.Contracts.csproj .
COPY library/Library.Persistence/Library.Persistence.csproj .
COPY library/Library.Domain/Library.Domain.csproj .
COPY library/Library.Application/Library.Application.csproj .
COPY library/Library.Infrastructure/Library.Infrastructure.csproj .
COPY *.sln .
RUN dotnet restore

# Copy everything else and build the app
COPY . ./
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /library/out .

# Set the entry point
ENTRYPOINT ["dotnet", "MyMvcApp.dll"]