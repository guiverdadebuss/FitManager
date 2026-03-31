using FitManager.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;

namespace FitManager.Data
{
    public static class DatabaseConnection
    {
        private static readonly string connString = ConfigurationManager.AppSettings["ConnectionString"];

        public static SqlConnection GetConnection()
        {
            if (string.IsNullOrEmpty(connString))
            {
                throw new Exception("A string de conexão não foi encontrada no App.config!");
            }

            return new SqlConnection(connString);
        }
    }
}




// CODIGO PARA QUERYS

//public static bool RegistarEntrada(int socioId)
//{
//    try
//    {
//        using (SqlConnection sqlConnection = DatabaseConnection.GetConnection())
//        {
//            sqlConnection.Open();
//            // ... codigo ...
//        }
//    }
//    catch (Exception ex) { throw ex; }
//}