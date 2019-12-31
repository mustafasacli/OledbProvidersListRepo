using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace OledbProvidersListCA
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (DataTable providers = DbProviderFactories.GetFactoryClasses())
            {
                Console.WriteLine("Available ADO.NET Data Providers:");
                foreach (DataRow prov in providers.Rows)
                {
                    Console.WriteLine("Name:{0}", prov["Name"]);
                    Console.WriteLine("Description:{0}", prov["Description"]);
                    Console.WriteLine("Invariant Name:{0}", prov["InvariantName"]);
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
