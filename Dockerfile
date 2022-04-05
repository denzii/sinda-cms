#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM node:lts AS node
COPY . .
WORKDIR "/client/"
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SindaCMS.csproj", "."]
RUN dotnet restore "SindaCMS.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "SindaCMS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SindaCMS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=node /wwwroot ./wwwroot
ENTRYPOINT ["dotnet", "SindaCMS.dll"]
