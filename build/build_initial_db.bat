pushd ..\
dotnet ef migrations add %1 -s src\FeatureToggle.NET.Web\FeatureToggle.NET.Web.csproj -p src\FeatureToggle.NET.Services\FeatureToggle.NET.Services.csproj --context SqlLiteDbContext
dotnet ef database update -s src\FeatureToggle.NET.Web\FeatureToggle.NET.Web.csproj -p src\FeatureToggle.NET.Services\FeatureToggle.NET.Services.csproj --context SqlLiteDbContext
popd .