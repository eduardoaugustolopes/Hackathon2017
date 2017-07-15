using CidadaoAlerta.Domain.Entities;
using CidadaoAlerta.Domain.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Text;

namespace CidadaoAlerta.Data.ADO.Repository
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        public void Add(Ocorrencia ocorrencia)
        {
            var query = new StringBuilder();
            query.Append(" INSERT INTO ocorrencia      ");
            query.Append(" (                           ");
            query.Append(" usuario_id,                 ");
            query.Append(" tipo_ocorrencia,                  ");
            query.Append(" tipo_item,               ");
            query.Append(" data,                  ");
            query.Append(" descricao,                     ");
            query.Append(" latitude,                   ");
            query.Append(" longitude                    ");
            query.Append(" )                           ");
            query.Append(" VALUES                      ");
            query.Append(" (                           ");
            query.Append(" ?usuario_id,                ");
            query.Append(" ?tipo_ocorrencia,                 ");
            query.Append(" ?tipo_item,              ");
            query.Append(" ?data,                 ");
            query.Append(" ?descricao,                    ");
            query.Append(" ?latitude,                  ");
            query.Append(" ?longitude                ");
            query.Append(" );                          ");
            query.Append(" SELECT LAST_INSERT_ID();    ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?usuario_id", ocorrencia.Usuario.Id);
            mySqlCommand.Parameters.AddWithValue("?tipo_ocorrencia", ocorrencia.TipoOcorrencia);
            mySqlCommand.Parameters.AddWithValue("?tipo_item", ocorrencia.TipoItem);
            mySqlCommand.Parameters.AddWithValue("?data", ocorrencia.Data);
            mySqlCommand.Parameters.AddWithValue("?descricao", ocorrencia.Descricao);
            mySqlCommand.Parameters.AddWithValue("?latitude", ocorrencia.Latitude);
            mySqlCommand.Parameters.AddWithValue("?longitude", ocorrencia.Longitude);
            ocorrencia.Id = Convert.ToInt32(mySqlCommand.ExecuteScalar());
        }
    }
}
