#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DemoAPI.Infrastructure/DemoAPI.Infrastructure.csproj", "DemoAPI/src/DemoAPI.Infrastructure/"]
COPY ["DemoAPI.SharedKernel/DemoAPI.SharedKernel.csproj", "DemoAPI/src/DemoAPI.SharedKernel/"]
COPY ["DemoAPI.Core/DemoAPI.Core.csproj", "DemoAPI/src/DemoAPI.Core/"]
COPY ["DemoAPI.Web/DemoAPI.Web.csproj", "DemoAPI.Web/"]
RUN dotnet restore "DemoAPI.Web/DemoAPI.Web.csproj"
COPY . .
WORKDIR "/src/DemoAPI.Web"
RUN dotnet build "DemoAPI.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoAPI.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoAPI.Web.dll"]