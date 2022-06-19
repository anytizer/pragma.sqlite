# pragma.sqlite

Table structure viewer for SQLite

* Connects to the user-selected .db file.
* Looks up for list of tables.
* Fetches table structures when you choose a table.
* Basic hints on other SQL operations

## How to?

* Clone the repo.
* Restore nuget packages using C#/Visual Studio.
* Compile pragma.sqlite.sln solution file, and run it.
* File > Open > Choose a .db sqlite file to proceed.
* Choose different tables to load the structure.

![screenshot](resources/screenshot.png)

## Libraries used:

* Microsoft.Data.Sqlite
* SQLitePCLRaw
