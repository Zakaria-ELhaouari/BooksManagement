## syntax=docker/dockerfile:1
#FROM mcr.microsoft.com/dotnet/aspnet:5.0
#WORKDIR /app
#
#COPY /app /app
#
#ENTRYPOINT ["dotnet", "BooksManagement.dll"]

# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY *.sln .
COPY BooksManagement/*.csproj BooksManagement/
#COPY Colors.API/*.csproj Colors.API/
RUN dotnet restore
COPY . .

# testing
FROM build AS testing
WORKDIR /src/BooksManagement
RUN dotnet build
#WORKDIR /src/Colors.UnitTests
#RUN dotnet test

# publish
FROM build AS publish
WORKDIR /src/BooksManagement
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT ["dotnet", "Colors.API.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Colors.API.dll