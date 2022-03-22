# Exercise Project: School API with .NET 5 and SQL Server

### appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "DbSettings": {
    "Port": 1431,
    "Host": "localhost",
    "Name": "master",
    "Username": "sa",
    "Password": "Sup3rS3cur3P4ssw0rd"
  }
}
```

### .env

```text
DB_PORT=1431
DB_HOST=localhost
DB_NAME=master
DB_USERNAME=sa
DB_PASSWORD=Sup3rS3cur3P4ssw0rd
```
