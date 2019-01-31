FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["FeatureToggle.NET.Web/FeatureToggle.NET.Web.csproj", "FeatureToggle.NET.Web/"]
RUN dotnet restore "FeatureToggle.NET.Web/FeatureToggle.NET.Web.csproj"
COPY . .
WORKDIR "/src/FeatureToggle.NET.Web"
RUN dotnet build "FeatureToggle.NET.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FeatureToggle.NET.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FeatureToggle.NET.Web.dll"]