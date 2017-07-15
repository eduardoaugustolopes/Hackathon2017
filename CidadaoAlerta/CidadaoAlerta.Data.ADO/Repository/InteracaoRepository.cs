using System;
using CidadaoAlerta.Domain.Entities;
using CidadaoAlerta.Domain.Interfaces;
using MySql.Data.MySqlClient;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace CidadaoAlerta.Data.ADO.Repository
{
    public class InteracaoRepository : IInteracaoRepository
    {
        public void Add(Interacao interacao)
        {
            var query = new StringBuilder();
            query.Append(" INSERT INTO ocorrencia      ");
            query.Append(" (                           ");
            query.Append(" usuario_id,                 ");
            query.Append(" ocorrencia_id,              ");
            query.Append(" data,                       ");
            query.Append(" descricao,                  ");
            query.Append(" latitude,                   ");
            query.Append(" longitude                   ");
            query.Append(" )                           ");
            query.Append(" VALUES                      ");
            query.Append(" (                           ");
            query.Append(" ?usuario_id,                ");
            query.Append(" ?ocorrencia_id,             ");
            query.Append(" ?data,                      ");
            query.Append(" ?descricao,                 ");
            query.Append(" ?latitude,                  ");
            query.Append(" ?longitude                  ");
            query.Append(" );                          ");
            query.Append(" SELECT LAST_INSERT_ID();    ");
            var mySqlCommand = new MySqlCommand(
                query.ToString(), DataContext.MySqlConnection, DataContext.MySqlTransaction);
            mySqlCommand.Parameters.AddWithValue("?usuario_id", interacao.Usuario.Id);
            mySqlCommand.Parameters.AddWithValue("?ocorrencia_id", interacao.Ocorrencia.Id);
            mySqlCommand.Parameters.AddWithValue("?data", interacao.Data);
            mySqlCommand.Parameters.AddWithValue("?descricao", interacao.Descricao);
            mySqlCommand.Parameters.AddWithValue("?latitude", interacao.Latitude);
            mySqlCommand.Parameters.AddWithValue("?longitude", interacao.Longitude);
            interacao.Id = Convert.ToInt32(mySqlCommand.ExecuteScalar());
        }

        public List<Interacao> GetPorOcorrencia(int ocorrenciaId)
        {
            var interacao = new List<Interacao>();

            var dataTable = new DataTable();
            var query = new StringBuilder();

            query.Append(" SELECT *                       ");
            query.Append(" FROM interacao                 ");
            query.Append(" WHERE                          ");
            query.Append(" ocorrencia_id = ?ocorrencia_id ");

            var mySqlCommand = new MySqlCommand(
                query.ToString(),
                DataContext.MySqlConnection,
                DataContext.MySqlTransaction);

            mySqlCommand.Parameters.AddWithValue("?ocorrencia_id", ocorrenciaId);

            dataTable.Load(mySqlCommand.ExecuteReader());
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var row = dataTable.Rows[i];
                interacao.Add(new Interacao()
                {
                    Id = Convert.ToInt32(row["interacao_id"]),
                    Ocorrencia = new Ocorrencia()
                    {
                        Id = Convert.ToInt32(row["ocorrencia_id"])
                    },
                    Usuario = new Usuario()
                    {
                        Id = Convert.ToInt32(row["usuario_id"])
                    },
                    Data = Convert.ToDateTime(row["data"]),
                    Descricao = row["descricao"].ToString(),
                    Latitude = row["latitude"].ToString(),
                    Longitude = row["longitude"].ToString()
                });
            }
            return interacao;
        }
    }
}
