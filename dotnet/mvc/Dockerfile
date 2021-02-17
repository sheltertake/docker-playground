FROM mcr.microsoft.com/dotnet/core/aspnet
COPY dist /app
WORKDIR /app
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "mvc.dll"]