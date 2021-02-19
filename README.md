## CONTENT
- Deconstruct
- Nova sintaxe switch
- FromServices
- EntityFrameworkCore InMemory
- CQRS
- FailFastValidation
- Queries
- Builders
TODO: Logging
TODO: Caching

## DOCKER SETUP:
    SQL Server

docker pull mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=" -p 1433:1433 --name handsOn -d mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04

docker start >container_id<
