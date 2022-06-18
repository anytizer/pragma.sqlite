﻿using Microsoft.Data.Sqlite;
using System.Data;

namespace pragma
{
    public class SQLiteDatabaseConnection
    {
        private SqliteConnection connection;

        public SQLiteDatabaseConnection()
        {

        }

        public void ConnectTo(string datafile)
        { 
            SqliteConnectionStringBuilder csb = new SqliteConnectionStringBuilder();
            csb.DataSource = datafile;
            csb.ForeignKeys = true;
            csb.Password = "";

            this.connection = new SqliteConnection(csb.ConnectionString);

            this.InstallProvidersOnConnection(this.connection);

            this.connection.Open();
        }

        public SqliteCommand Command()
        {
            SqliteCommand command = this.connection.CreateCommand();
            command.CommandType = CommandType.Text;

            return command;
        }

        private void InstallProvidersOnConnection(SqliteConnection connection)
        {
            // https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/user-defined-functions
            connection.CreateFunction("GUID", () => {
                Providers p = new Providers();

                string guid = p.id();
                return guid;
            });

            connection.CreateFunction("NOW", () => {
                Providers p = new Providers();

                string now = p.now();
                return now;
            });
        }
    }
}