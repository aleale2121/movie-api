MigratePersistence:
	dotnet ef migrations add InitialCreate --project Persistence -c MOVIEAPPDbContext --startup-project WebApi

AddSeedPersistence:
	dotnet ef migrations add AddSeedData  --project Persistence  -c MOVIEAPPDbContext --startup-project WebApi

MigrateUpdatePersistence:
	dotnet ef database update --project Persistence -c MOVIEAPPDbContext --startup-project WebApi

RemoveMigrations:
	dotnet ef migrations remove --project Persistence -c MOVIEAPPDbContext --startup-project WebApi