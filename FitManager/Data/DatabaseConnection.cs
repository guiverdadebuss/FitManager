using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace FitManager.Data
{
    public static class DatabaseConnection
    {
        private static string connString = @"Server=GUILHERMEBUSS\SQLEXPRESS;Database=FitManager;Trusted_Connection=True;";

        public static SqlConnection GetConnection() => new SqlConnection(connString);
    }
}
