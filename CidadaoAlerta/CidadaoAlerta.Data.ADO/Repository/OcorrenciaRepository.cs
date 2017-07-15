using CidadaoAlerta.Domain.Entities;
using CidadaoAlerta.Domain.Enums;
using CidadaoAlerta.Domain.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<Ocorrencia> Get()
        {
            var ocorrencias = new List<Ocorrencia>();

            var dataTable = new DataTable();
            var query = new StringBuilder();

            query.Append(" SELECT *                                                ");
            query.Append(" FROM ocorrencia                                         ");
            query.Append(" LIMIT ?Skip,?Top                                        ");

            var mySqlCommand = new MySqlCommand(
                query.ToString(),
                DataContext.MySqlConnection,
                DataContext.MySqlTransaction);

            mySqlCommand.Parameters.AddWithValue("?Skip", 0);
            mySqlCommand.Parameters.AddWithValue("?Top", 10);

            dataTable.Load(mySqlCommand.ExecuteReader());
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var row = dataTable.Rows[i];
                ocorrencias.Add(new Ocorrencia()
                {
                    Id = Convert.ToInt32(row["ocorrencia_id"]),
                    Usuario = new Usuario()
                    {
                        Id = Convert.ToInt32(row["usuario_id"])
                    },
                    TipoOcorrencia = (TipoOcorrenciaEnum) Convert.ToInt32(row["tipo_ocorrencia"]),
                    TipoItem = (TipoItemEnum) Convert.ToInt32(row["tipo_item"]),
                    Data = Convert.ToDateTime(row["data"]),
                    Descricao = row["descricao"].ToString(),
                    Latitude = row["latitude"].ToString(),
                    Longitude = row["longitude"].ToString()
                });
            }
            return ocorrencias;
        }

        public Ocorrencia Get(int id)
        {
            var ocorrencia = new Ocorrencia();

            var dataTable = new DataTable();
            var query = new StringBuilder();

            query.Append(" SELECT *                                                ");
            query.Append(" FROM ocorrencia                                         ");
            query.Append(" WHERE                                        ");
            query.Append(" ocorrencia_id = ?ocorrencia_id                                        ");

            var mySqlCommand = new MySqlCommand(
                query.ToString(),
                DataContext.MySqlConnection,
                DataContext.MySqlTransaction);

            mySqlCommand.Parameters.AddWithValue("?ocorrencia_id", id);

            dataTable.Load(mySqlCommand.ExecuteReader());
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                ocorrencia = new Ocorrencia()
                {
                    Id = Convert.ToInt32(row["ocorrencia_id"]),
                    Usuario = new Usuario()
                    {
                        Id = Convert.ToInt32(row["usuario_id"])
                    },
                    TipoOcorrencia = (TipoOcorrenciaEnum)Convert.ToInt32(row["tipo_ocorrencia"]),
                    TipoItem = (TipoItemEnum)Convert.ToInt32(row["tipo_item"]),
                    Data = Convert.ToDateTime(row["data"]),
                    Descricao = row["descricao"].ToString(),
                    Latitude = row["latitude"].ToString(),
                    Longitude = row["longitude"].ToString()
                };
            }

            return ocorrencia;
        }
    }
}
