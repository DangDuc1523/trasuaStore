FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY TraSuaMoc.API/TraSuaMoc.API.csproj TraSuaMoc.API/
RUN dotnet restore TraSuaMoc.API/TraSuaMoc.API.csproj
COPY . .
RUN dotnet publish TraSuaMoc.API/TraSuaMoc.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "TraSuaMoc.API.dll"]
