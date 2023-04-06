FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Project_API/Project_API.csproj", "Project_API/"]
RUN dotnet restore "Project_API/Project_API.csproj"
COPY . .
WORKDIR "/src/Project_API"
RUN dotnet build "Project_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project_API.dll"]
