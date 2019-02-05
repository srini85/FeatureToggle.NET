pushd ..\
rmdir /q/s src\FeatureToggle.NET.Services\migrations
del /q/s src\FeatureToggle.NET.Web\FeatureToggle.db

dotnet ef migrations add initial_db -s src\FeatureToggle.NET.Web\FeatureToggle.NET.Web.csproj -p src\FeatureToggle.NET.Services\FeatureToggle.NET.Services.csproj --context SqlLiteDbContext
dotnet ef database update -s src\FeatureToggle.NET.Web\FeatureToggle.NET.Web.csproj -p src\FeatureToggle.NET.Services\FeatureToggle.NET.Services.csproj --context SqlLiteDbContext
popd .