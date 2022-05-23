FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR .obj
COPY ./bin/Release/net5.0 /app/publish
ENTRYPOINT ["dotnet", "/app/publish/SOSU_BackEnd.WebApi.dll"]
