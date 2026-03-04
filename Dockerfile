# Use the official ASP.NET Core image.
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official SDK image for building the application.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY [your csproj file path] .
RUN dotnet restore
COPY . .
WORKDIR /src/[your project directory]
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Final stage: build the image from the published output.
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "[your project dll].dll"]
