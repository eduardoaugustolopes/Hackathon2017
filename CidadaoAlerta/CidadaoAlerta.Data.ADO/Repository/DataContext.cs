using CidadaoAlerta.Domain.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace CidadaoAlerta.Data.ADO.Repository
{
    public class DataContext : IDataContext
    {
        public static MySqlConnection MySqlConnection { get; set; }
        public static MySqlTransaction MySqlTransaction { get; set; }

        public void BeginTransaction()
        {
            MySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["CidadaoAlerta"].ConnectionString);
            MySqlConnection.Open();
            MySqlTransaction = MySqlConnection.BeginTransaction();
        }

        public void Commit()
        {
            MySqlTransaction.Commit();
        }

        public void Rollback()
        {
            MySqlTransaction.Rollback();
        }

        public void Finally()
        {
            if (MySqlTransaction != null)
            {
                MySqlTransaction.Dispose();
            }
            if (MySqlConnection != null)
            {
                MySqlConnection.Close();
                MySqlConnection.Dispose();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
