# PowerDiary.TestApp

## Projects Overview:
**PowerDiary.TestApp.Services:** Service Layer containing the business logic

**PowerDiary.TestApp.Shared:** Defines the dtos and the interfaces of the service layer. Can be shared with clients (windows, mobile,etc..) as contracts.

**PowerDiary.TestApp.EntityFrameworkCore:** Contains the dbContext, migrations, stored procedures, and other db related stuff.

**PowerDiary.TestApp.Core:** Defines core entities (db tables), and other core stuff meant for the server only.

**PowerDiary.TestApp.Web:** Hosts the angular client, and the api controllers which act as a very thin layer and call the service layer.

**PowerDiary.TestApp.Tests:** XUnit Tests

## Requirements:
.NET 5.0, Sql Server (Mine was 2017, but should work for almost any version)

## Instructions:
Just run the project with Visual Studio, or dotnet run. It will create and migrate the db.

Tests: dotnet test or run with VS.
