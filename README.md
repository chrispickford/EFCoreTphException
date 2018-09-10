# EFCoreTphException

`System.InvalidOperationException: A discriminator property cannot be set for the entity type 'QuestionBase' because it is not the root of an inheritance hierarchy.`

Created as a working example of this EF Core issue:
https://github.com/aspnet/EntityFrameworkCore/issues

## Steps to reproduce
- Clone & Build project
- CLI: `dotnet ef migrations add CreateDatabase`