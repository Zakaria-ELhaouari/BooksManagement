# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY *.sln .
COPY BooksManagement/*.csproj BooksManagement/
RUN dotnet restore
COPY . .

# testing
FROM build AS testing
WORKDIR /src/BooksManagement
RUN dotnet build

# publish
FROM build AS publish
WORKDIR /src/BooksManagement
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet BooksManagement.dll