using System;
using System.Collections.Generic;
using System.Text;

namespace pragma
{
    class pragma: SQLiteDatabaseOperator
    {
        public List<ComboItemDTO> get_tables()
        {
            List<ComboItemDTO> tables = new List<ComboItemDTO>();

            string sql = "SELECT tbl_name FROM \"main\".sqlite_master where type=\"table\";";
            List<string[]> tables1 = this.Query(sql);
            foreach(string[] table in tables1)
            {
                tables.Add(new ComboItemDTO() { Name = table[0], Value = table[0] });
            }

            return tables;
        }

        public string get_info(string tablename)
        {
            List<KVDTO> parameters = new List<KVDTO>();
            parameters.Add(new KVDTO() { k = "name", v = tablename });

            List<string[]> output = this.Query("SELECT sql FROM \"main\".sqlite_master WHERE name=@name;", parameters);

            return string.Join("\r\n", output[0][0].Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
