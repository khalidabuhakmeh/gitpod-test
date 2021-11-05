# gitpod-test


## SQL Server Commands

Run these after the database has updated to access `sqlserver` docker container.

### Connect to SQL Server with Bash

```console
docker exec -it sqlserver  "bash"
```

### Run Queries

```console
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Pass123!' -Q "select * from test.dbo.Numbers"
```