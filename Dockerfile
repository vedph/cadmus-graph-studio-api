# Stage 1: base
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

# Stage 2: build
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["CadmusGraphStudioApi/CadmusGraphStudioApi.csproj", "CadmusGraphStudioApi/"]
RUN dotnet restore "CadmusGraphStudioApi/CadmusGraphStudioApi.csproj" -s https://api.nuget.org/v3/index.json --verbosity d
# copy the content of the API project
COPY . .
# build it
RUN dotnet build "CadmusGraphStudioApi/CadmusGraphStudioApi.csproj" -c Release -o /app/build

# Stage 3: publish
FROM build AS publish
RUN dotnet publish "CadmusGraphStudioApi/CadmusGraphStudioApi.csproj" -c Release -o /app/publish

# Stage 4: final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CadmusGraphStudioApi.dll"]