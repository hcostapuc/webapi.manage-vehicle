#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["webapi.manage-vehicle/webapi.manage-vehicle.csproj", "webapi.manage-vehicle/"]
RUN dotnet restore "webapi.manage-vehicle/webapi.manage-vehicle.csproj"
COPY . .
WORKDIR "/src/webapi.manage-vehicle"
RUN dotnet build "webapi.manage-vehicle.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "webapi.manage-vehicle.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webapi.manage-vehicle.dll"]