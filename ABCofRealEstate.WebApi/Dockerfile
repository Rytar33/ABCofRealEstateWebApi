FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ABCofRealEstate.WebApi/ABCofRealEstate.WebApi.csproj", "ABCofRealEstate.WebApi/"]
COPY ["ABCofRealEstate.Data.Models/ABCofRealEstate.Data.Models.csproj", "ABCofRealEstate.Data.Models/"]
COPY ["ABCofRealEstate.Data.Enums/ABCofRealEstate.Data.Enums.csproj", "ABCofRealEstate.Data.Enums/"]
COPY ["ABCofRealEstate.Services/ABCofRealEstate.Services.csproj", "ABCofRealEstate.Services/"]
COPY ["ABCofRealEstate.DataBaseContext/ABCofRealEstate.DataBaseContext.csproj", "ABCofRealEstate.DataBaseContext/"]
COPY ["ABCofRelEstate.ExportTool/ABCofRelEstate.ExportTool.csproj", "ABCofRelEstate.ExportTool/"]
RUN dotnet restore "ABCofRealEstate.WebApi/ABCofRealEstate.WebApi.csproj"
COPY . .
WORKDIR "/src/ABCofRealEstate.WebApi"
RUN dotnet build "ABCofRealEstate.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ABCofRealEstate.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ABCofRealEstate.WebApi.dll"]
