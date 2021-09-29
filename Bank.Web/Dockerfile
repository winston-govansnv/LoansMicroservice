#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Bank.Web/Bank.Web.csproj", "Bank.Web/"]
COPY ["Bank.Core/Bank.Core.csproj", "Bank.Core/"]
COPY ["Bank.DataAccess/Bank.DataAccess.csproj", "Bank.DataAccess/"]
COPY ["Bank.Models/Bank.Models.csproj", "Bank.Models/"]
RUN dotnet restore "Bank.Web/Bank.Web.csproj"
COPY . .
WORKDIR "/src/Bank.Web"
RUN dotnet build "Bank.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bank.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bank.Web.dll"]
