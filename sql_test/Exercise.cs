using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_test
{
    class Exercise
    {   

        public Exercise(List<Table> tables)
        {
            var rnd = new Random();
            var table = tables[rnd.Next(tables.Count())];
            var col = table.getColumns()[rnd.Next(table.getColumns().Count())];
            
        }
        public void print()
        {
            Console.WriteLine("Exercise created");
        }
    }
}
