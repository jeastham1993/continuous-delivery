# Continuous Delivery

A simple .NET Core API to use for testing the concepts and practices described in the Continuous Delivery book by Dave Farley and Jez Humble.

## Manual Testing

It is recommended to use docker-compose to run a local test version of the API, this ensures that any dependent infrastructure is also started at the same time. From the repository root, run the below command to start an instance of the API on port 5000.

``` bash

docker-compose up -d

```

If you do not have Docker installed, you can manually start an instance of the API using 

``` bash

dotnet run -p src/JEasthamDev.Api/JEasthamDev.Api.csproj

```
## Automated Testing

To build and test the application locally, run 

``` bash

commit.sh

```

If you would like to run the full suite of acceptance tests then run

``` bash

acceptance.sh

```

