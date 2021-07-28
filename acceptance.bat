docker build -f .\src\JEasthamDev.Api\Dockerfile -t jeasthamdev-api .

if %errorlevel% neq 0 exit /b %errorlevel%

docker run -p 5000:80 -d jeasthamdev-api

if %errorlevel% neq 0 exit /b %errorlevel%

dotnet test test/JEasthamDev.AcceptanceTest/JEasthamDev.AcceptanceTest.csproj

if %errorlevel% neq 0 exit /b %errorlevel%