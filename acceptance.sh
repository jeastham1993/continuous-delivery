docker-compose up -d

sleep 3s

pip3 install awscli-local

awslocal cloudformation deploy --template-file ./infrastructure/infrastructure.yml --stack-name jeasthamdev-api

sleep 3s

dotnet test test/JEasthamDev.AcceptanceTests/JEasthamDev.AcceptanceTests.csproj

docker build -f ./src/JEasthamDev.Api/Dockerfile -t jeasthamdev-api .