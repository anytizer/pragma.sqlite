# pragma.sqlite

Table structure viewer for SQLite

* Connects to the user-selected .db file.
* Looks up for list of tables.
* Fetches table structures when you choose a table.
* Basic hints on other SQL operations

## How to?

* Clone the repo.
* Open src/pragma.sqlite.sln
* Restore nuget packages using C#/Visual Studio.
* Compile it, and run.
* File > Open > Choose a .db sqlite file to proceed.
* Choose different tables to load the structure.

## Dependencies
* [dotnet 7](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Microsoft.Data.Sqlite]()
* [SQLitePCLRaw]()

![screenshot](resources/screenshot.png)

It is a generic experimental product that shows:
* Connecting to SQLite Database.
* PRAGMA queries
