FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AdaYazilimProject/AdaYazilimProject.csproj", "AdaYazilimProject/"]
RUN dotnet restore "AdaYazilimProject/AdaYazilimProject.csproj"
COPY . .
WORKDIR "/src/AdaYazilimProject"
RUN dotnet build "AdaYazilimProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdaYazilimProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdaYazilimProject.dll", "--urls", "http://0.0.0.0:10000"]
 