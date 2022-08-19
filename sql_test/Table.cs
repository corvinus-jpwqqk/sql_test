using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_test
{
    class Table
    {
        private int _objId;
        private string _name;
        private List<Column> _columns;

        public Table(int objId_, string name_)
        {
            _objId = objId_;
            _name = name_;
            _columns = new List<Column>();
        }
        public void addCol(Column in_)
        {
            _columns.Add(in_);
        }

        public string prt()
        {
            return "Table: " + _name + ", with object id: " + _objId.ToString() + ", with " + _columns.Count().ToString() + " columns. ";
        }

        public int getObjId()
        {
            return _objId;
        }
        public string getName()
        {
            return _name;
        }

        public void getColumns(SqlConnection conn)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while connecting in getColums");
                Console.WriteLine(ex.Message);
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM sys.columns WHERE object_id = " + _objId, conn);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Column c = new Column(Convert.ToInt32(rdr[0]), Convert.ToInt32(rdr[2]), Convert.ToInt32(rdr[3]), Convert.ToInt32(rdr[5]), rdr[1].ToString());
                    this.addCol(c);
                }
            }
            conn.Close();
        }
    }
}
