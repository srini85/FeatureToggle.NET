@echo off
if "%1"=="" echo You must enter a name for the migration as the first argument && goto :end
pushd ..\
dotnet ef migrations add %1 -s src\FeatureToggle.NET.Web\FeatureToggle.NET.Web.csproj -p src\FeatureToggle.NET.Store\FeatureToggle.NET.Store.csproj
dotnet ef database update -s src\FeatureToggle.NET.Web\FeatureToggle.NET.Web.csproj -p src\FeatureToggle.NET.Store\FeatureToggle.NET.Store.csproj
popd .

:end