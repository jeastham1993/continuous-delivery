dotnet clean
dotnet restore src/JEasthamDev.Api/JEasthamDev.Api.csproj
dotnet build src/JEasthamDev.Api/JEasthamDev.Api.csproj
dotnet test test/JEasthamDev.UnitTest/JEasthamDev.UnitTest.csproj

docker build -f .\src\JEasthamDev.Api\Dockerfile -t jeasthamdev-api .