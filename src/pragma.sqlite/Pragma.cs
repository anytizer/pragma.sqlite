using System;
using System.Collections.Generic;
using System.Text;

namespace pragma.sqlite
{
    class Pragma : SQLiteDatabaseOperator
    {
        public Pragma()
        {

        }

        public List<ComboItemDTO> get_tables()
        {
            List<ComboItemDTO> tables = new List<ComboItemDTO>();

            string sql = "SELECT tbl_name FROM sqlite_master WHERE type=\"table\";";
            List<string[]> tables1 = Query(sql);
            foreach (string[] table in tables1)
            {
                tables.Add(new ComboItemDTO() { Name = table[0], Value = table[0] });
            }

            return tables;
        }

        public string create(string tablename)
        {
            List<KVDTO> parameters = new List<KVDTO>();
            parameters.Add(new KVDTO() { k = "tablename", v = tablename });

            List<string[]> output = Query("SELECT sql FROM sqlite_master WHERE name=@tablename;", parameters);

            return string.Join("\r\n", output[0][0].Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
        }

        internal string version()
        {
            return "V1.0.0";
        }

        internal string insert(string tablename)
        {
            List<KVDTO> parameters = new List<KVDTO>();
            parameters.Add(new KVDTO() { k = "tablename", v = tablename });

            //string sql = "PRAGMA TABLE_INFO(@tablename);";
            // List<string[]> output = this.Query(sql, parameters);

            return string.Format("INSERT INTO `{0}` () VALUES ();", tablename);
        }

        internal string flag(string tablename)
        {
            return string.Format("UPDATE `{0}` SET is_flagged='Y' WHERE id=:id;", tablename);
        }

        internal string delete(string tablename)
        {
            return string.Format("DELETE FROM `{0}` WHERE id=:id;", tablename);
        }

        internal string update(string tablename)
        {
            return string.Format("UPDATE `{0}` SET `field`=@field WHERE id=:id;", tablename);
        }

        internal string purge(string tablename)
        {
            return string.Format("DELETE FROM `{0}` WHERE is_deleted='Y';", tablename);
        }
    }
}
