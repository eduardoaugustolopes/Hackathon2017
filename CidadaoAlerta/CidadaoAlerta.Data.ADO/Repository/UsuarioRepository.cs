using System;
using CidadaoAlerta.Domain.Entities;
using CidadaoAlerta.Domain.Interfaces;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace CidadaoAlerta.Data.ADO.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario Get(string login, string senha)
        {
            var usuario = new Usuario();
            var dataTable = new DataTable();
            var query = new StringBuilder();
            query.Append(" SELECT                 ");
            query.Append(" *                      ");
            query.Append(" FROM usuario           ");
            query.Append(" WHERE                  ");
            query.Append(" login = ?login AND     ");
            query.Append(" senha = ?senha         ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);

            mySqlCommand.Parameters.AddWithValue("?login", login);
            mySqlCommand.Parameters.AddWithValue("?senha", senha);

            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                usuario = new Usuario()
                {
                    Id = Convert.ToInt32(row["usuario_id"]),
                    Login = row["login"].ToString(),
                    Senha = row["senha"].ToString()
                };
            }
            return usuario;
        }
    }
}
