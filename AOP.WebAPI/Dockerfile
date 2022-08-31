#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AOP.WebAPI/AOP.WebAPI.csproj", "AOP.WebAPI/"]
RUN dotnet restore "AOP.WebAPI/AOP.WebAPI.csproj"
COPY . .
WORKDIR "/src/AOP.WebAPI"
RUN dotnet build "AOP.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AOP.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AOP.WebAPI.dll"]