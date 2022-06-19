using System.IO;

namespace pragma.sqlite
{
    class SQLiteDatabaseFile
    {
        public string FromConfigurations()
        {
            string LocalDataFile = "database.db";
            string LiveDataFile = "live.db";

            string datafile = File.Exists(LocalDataFile) ? LocalDataFile : LiveDataFile;
            return datafile;
        }
    }
}
