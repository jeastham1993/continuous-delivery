dotnet clean

dotnet restore src/JEasthamDev.Api/JEasthamDev.Api.csproj

dotnet build src/JEasthamDev.Api/JEasthamDev.Api.csproj

dotnet test test/JEasthamDev.UnitTest/JEasthamDev.UnitTest.csproj