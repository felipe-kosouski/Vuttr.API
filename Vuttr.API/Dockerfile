FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 3000
ENV ASPNETCORE_URLS=http://+:3000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Vuttr.API.csproj", "./"]
RUN dotnet restore "./Vuttr.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Vuttr.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vuttr.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Vuttr.API.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Vuttr.API.dll