#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./MapOfFeel.sln ./MapOfFeel.sln
COPY ./src/Backend/Backend.csproj ./src/Backend/Backend.csproj
COPY ./src/Database/Database.csproj ./src/Database/Database.csproj
RUN dotnet restore 
COPY . .
WORKDIR "/src/src/Backend"
RUN dotnet build -c Release --no-restore
RUN dotnet test

FROM build AS publish
RUN dotnet publish "Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false --no-build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.dll"]
