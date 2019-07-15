FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MatchPoint.WebApi/MatchPoint.WebApi.csproj", "MatchPoint.WebApi/"]
RUN dotnet restore "MatchPoint.WebApi/MatchPoint.WebApi.csproj"
COPY . .
WORKDIR "/src/MatchPoint.WebApi"
RUN dotnet build "MatchPoint.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MatchPoint.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MatchPoint.WebApi.dll"]