

dotnet ef migrations add entityrelation1 --project infrastructure/infrastructure.csproj --startup-project entityapi/entityapi.csproj

dotnet ef database update --project infrastructure/infrastructure.csproj --startup-project entityapi/entityapi.csproj