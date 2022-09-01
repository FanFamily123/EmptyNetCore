FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Swift.BBS.Api/Swift.BBS.Api.csproj", "Swift.BBS.Api/"]
RUN dotnet restore "Swift.BBS.Api/Swift.BBS.Api.csproj"
COPY . .
WORKDIR "/src/Swift.BBS.Api"
RUN dotnet build "Swift.BBS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Swift.BBS.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Swift.BBS.Api.dll"]
