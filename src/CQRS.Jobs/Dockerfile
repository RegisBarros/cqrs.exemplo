FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/CQRS.Jobs/CQRS.Jobs.csproj", "src/CQRS.Jobs/"]
COPY ["src/CQRS.Application/CQRS.Application.csproj", "src/CQRS.Application/"]
COPY ["src/CQRS.Persistence/CQRS.Persistence.csproj", "src/CQRS.Persistence/"]
COPY ["src/CQRS.Core/CQRS.Core.csproj", "src/CQRS.Core/"]
RUN dotnet restore "src/CQRS.Jobs/CQRS.Jobs.csproj"
COPY . .
WORKDIR "/src/src/CQRS.Jobs"
RUN dotnet build "CQRS.Jobs.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CQRS.Jobs.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CQRS.Jobs.dll"]
