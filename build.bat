cd /D "D:\username\Documents\Visual Studio 2017\Projects\EmbeddedWebsiteTest"

dotnet restore -r win-x64
dotnet build -r win-x64
dotnet publish -f netcoreapp2.0 -c Release -r win-x64
