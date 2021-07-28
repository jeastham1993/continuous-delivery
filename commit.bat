dotnet clean

if %errorlevel% neq 0 exit /b %errorlevel%

dotnet restore src/JEasthamDev.Api/JEasthamDev.Api.csproj

if %errorlevel% neq 0 exit /b %errorlevel%

dotnet build src/JEasthamDev.Api/JEasthamDev.Api.csproj

if %errorlevel% neq 0 exit /b %errorlevel%

dotnet test test/JEasthamDev.UnitTest/JEasthamDev.UnitTest.csproj

if %errorlevel% neq 0 exit /b %errorlevel%