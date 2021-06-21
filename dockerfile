# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY /app /app

ENTRYPOINT ["dotnet", "BooksManagement.dll"]