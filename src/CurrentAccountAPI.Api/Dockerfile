#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CurrentAccountAPI.Api/CurrentAccountAPI.Api.csproj", "CurrentAccountAPI.Api/"]
RUN dotnet restore "CurrentAccountAPI.Api/CurrentAccountAPI.Api.csproj"
COPY . .
WORKDIR "/src/CurrentAccountAPI.Api"
RUN dotnet build "CurrentAccountAPI.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CurrentAccountAPI.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CurrentAccountAPI.Api.dll"]