using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;

namespace OledbProvidersListCA
{
    class Program
    {
        static void Main(string[] args)
        {

            using (DataTable providers = DbProviderFactories.GetFactoryClasses())
            {
                Console.WriteLine("Available ADO.NET Data Providers:");
                var columns = providers.Columns;
                foreach (DataRow prov in providers.Rows)
                {
                    foreach (DataColumn column in columns)
                    {
                        Console.WriteLine("{0} : {1}", column.ColumnName, prov[column]);
                    }
                    //Console.WriteLine("Name:{0}", prov["Name"]);
                    //Console.WriteLine("Description:{0}", prov["Description"]);
                    //Console.WriteLine("Invariant Name:{0}", prov["InvariantName"]);
                    Console.WriteLine("------------------------------------------------------------");
                }
            }

            Console.WriteLine("/*****************************************************/");
            using (OleDbDataReader dataReader = OleDbEnumerator.GetRootEnumerator())
            {
                while (dataReader.Read())
                {
                    Console.WriteLine("*- {0}, {1}", dataReader[0], dataReader[2]);
                }
            }

            Console.Read();
        }
    }
}
