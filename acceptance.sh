docker-compose up -d

sleep 10s

pip3 install awscli-local

pip3 install --upgrade awscli

pip3 install --upgrade awscli-local

awslocal cloudformation deploy --template-file ./infrastructure/infrastructure.yml --stack-name jeasthamdev-api

sleep 10s

dotnet test test/JEasthamDev.AcceptanceTests/JEasthamDev.AcceptanceTests.csproj

docker build -f ./src/JEasthamDev.Api/Dockerfile -t jeasthamdev-api .