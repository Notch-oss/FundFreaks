#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Investor_Service/Investor_Service.csproj", "Investor_Service/"]
RUN dotnet restore "Investor_Service/Investor_Service.csproj"
COPY . .
WORKDIR "/src/Investor_Service"
RUN dotnet build "Investor_Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Investor_Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Investor_Service.dll"]