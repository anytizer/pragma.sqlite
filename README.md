# pragma.sqlite

Table structure viewer for SQLite

* Connects to the user-selected .db sqlite database file.
* Looks up for list of tables.
* Fetches table structures when you select a table.
* Basic hints on other SQL operations.

## How to?

* Clone the repo.
* Open src/pragma.sqlite.sln
* Restore nuget packages using C#/Visual Studio.
* Compile it, and run.
* File > Open > Choose a .db sqlite file to proceed.
* Choose different tables to load the structure.

## Dependencies
* [dotnet 7](https://dotnet.microsoft.com/en-us/download/dotnet) preview
* [Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite/) - MIT license
* [Microsoft.Data.Sqlite.Core](https://www.nuget.org/packages/Microsoft.Data.Sqlite.Core) - MIT license
* [SQLitePCLRaw.bundle_e_sqlite3](https://www.nuget.org/packages/SQLitePCLRaw.bundle_e_sqlite3) - Apache-2.0 license

![screenshot](resources/screenshot.png)

It is a generic experimental product that shows:
* Connecting to SQLite Database using C# under [dotnet](https://dotnet.microsoft.com/) 7.
* PRAGMA queries.
* CREATE info of a table.
* Sample SQLs for insert, flag, delete kind of queries.

## Samples
See more information in [sample](sample/) for the attached database.
