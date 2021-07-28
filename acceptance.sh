docker build -f .\src\JEasthamDev.Api\Dockerfile -t jeasthamdev-api .

docker run -p 5000:80 -d jeasthamdev-api

dotnet test test/JEasthamDev.AcceptanceTest/JEasthamDev.AcceptanceTest.csproj