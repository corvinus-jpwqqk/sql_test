using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Server: ");
            //string server = Console.ReadLine();
            //Console.WriteLine("UserName: ");
            //string uname = Console.ReadLine();
            Console.WriteLine("Password: ");
            string pwd = Console.ReadLine();

            List<Table> tables = new List<Table>();

            string server = "bit.uni-corvinus.hu";
            string uname = "hallgato";
            string database = "szallashely";
            SqlCommand cmd;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=" + server + ";Database=" + database + ";Uid=" + uname + ";Password=" + pwd;
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while connecting: ");
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    return;
                }

                cmd = new SqlCommand("SELECT * FROM sys.tables", conn);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string tableName = (string)rdr[0];
                        int objectId = (int)rdr[1];
                        Table t = new Table(objectId, tableName);
                        tables.Add(t);
                    }
                }
                conn.Close();
                foreach (var t in tables)
                {
                    t.getColumns(conn);
                    Console.WriteLine(t.prt());
                }
            }
            Console.ReadKey();

        }
    }
}
