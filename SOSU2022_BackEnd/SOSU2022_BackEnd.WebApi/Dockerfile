FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SOSU2022_BackEnd/SOSU2022_BackEnd.csproj", "SOSU2022_BackEnd/"]
RUN dotnet restore "SOSU2022_BackEnd/SOSU2022_BackEnd.csproj"
COPY . .
WORKDIR "/src/SOSU2022_BackEnd"
RUN dotnet build "SOSU2022_BackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SOSU2022_BackEnd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SOSU2022_BackEnd.dll"]
