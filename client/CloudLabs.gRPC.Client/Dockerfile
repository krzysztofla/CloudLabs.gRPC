FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["client/CloudLabs.gRPC.Client/CloudLabs.gRPC.Client.csproj", "CloudLabs.gRPC.Client/"]
RUN dotnet restore "client/CloudLabs.gRPC.Client/CloudLabs.gRPC.Client.csproj"
COPY . .
WORKDIR "/src/CloudLabs.gRPC.Client"
RUN dotnet build "CloudLabs.gRPC.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudLabs.gRPC.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudLabs.gRPC.Client.dll"]
