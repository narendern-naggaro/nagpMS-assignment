#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["OrderServ/OrderServ.csproj", "OrderServ/"]
RUN dotnet restore "OrderServ/OrderServ.csproj"
COPY . .
WORKDIR "/src/OrderServ"
RUN dotnet build "OrderServ.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderServ.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderServ.dll"]