FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["lab3/lab3.csproj", "lab3/"]
RUN dotnet restore "lab3/lab3.csproj"
COPY . .
WORKDIR "/src/lab3"
RUN dotnet build "lab3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lab3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lab3.dll"]
