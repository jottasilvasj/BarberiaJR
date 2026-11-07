FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY Barbearia/Barbearia.csproj Barbearia/
RUN dotnet restore "Barbearia/Barbearia.csproj"
COPY . .
WORKDIR /src/Barbearia
RUN dotnet publish "Barbearia.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "Barbearia.dll"]