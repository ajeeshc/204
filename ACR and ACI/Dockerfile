#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Net6SimpleDocker/Net6SimpleDocker.csproj", "Net6SimpleDocker/"]
COPY . .

RUN dotnet restore "Net6SimpleDocker/Net6SimpleDocker.csproj"


WORKDIR "/src/Net6SimpleDocker"
RUN dotnet build "Net6SimpleDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Net6SimpleDocker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Net6SimpleDocker.dll"]