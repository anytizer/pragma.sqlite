using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Data;

namespace pragma
{
    // https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/transactions
    public class SQLiteDatabaseOperator : SQLiteDatabaseConnection
    {
        internal SqliteDataReader ParameterizedQuery(string sql, List<KVDTO> parameters)
        {
            SqliteCommand command = this.Command();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;

            foreach (KVDTO parameter in parameters)
            {
                string parameter_name = (parameter.k.StartsWith("@") ? "" : "@") + parameter.k;
                command.Parameters.Add(new SqliteParameter(parameter_name, parameter.v));
            }

            SqliteDataReader reader = command.ExecuteReader();
            return reader;
        }

        public List<string[]> Query(string sql, List<KVDTO> parameters)
        {
            SqliteDataReader reader = this.ParameterizedQuery(sql, parameters);

            List<string[]> output = new List<string[]>() { };
            while (reader.Read())
            {
                List<string> cols = new List<string>();
                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    string cell = "";
                    // cols.Add(reader.GetName(i));
                    if (!reader.IsDBNull(i))
                        cell = reader.GetString(i);

                    cols.Add(cell);
                }

                output.Add(cols.ToArray());
            }

            return output;
        }

        public void RawQuery(string sql, List<KVDTO> parameters)
        {
            this.ParameterizedQuery(sql, parameters);
        }

        public List<string[]> Query(string sql)
        {
            List<KVDTO> parameters = new List<KVDTO>() { };
            List<string[]> output = this.Query(sql, parameters);
            return output;
        }
    }
}
