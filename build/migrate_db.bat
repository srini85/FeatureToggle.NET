pushd ..\
dotnet ef database update -s src\FeatureToggle.NET.Web\FeatureToggle.NET.Web.csproj -p src\FeatureToggle.NET.Store\FeatureToggle.NET.Store.csproj
popd .