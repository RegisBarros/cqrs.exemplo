FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/CQRS.Api/CQRS.Api.csproj", "src/CQRS.Api/"]
COPY ["src/CQRS.Application/CQRS.Application.csproj", "src/CQRS.Application/"]
COPY ["src/CQRS.Persistence/CQRS.Persistence.csproj", "src/CQRS.Persistence/"]
COPY ["src/CQRS.Core/CQRS.Core.csproj", "src/CQRS.Core/"]
COPY nuget.config ./
RUN dotnet restore "src/CQRS.Api/CQRS.Api.csproj"
COPY . .
WORKDIR "/src/src/CQRS.Api"
RUN dotnet build "CQRS.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CQRS.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CQRS.Api.dll"]