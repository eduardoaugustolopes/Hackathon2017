using CidadaoAlerta.Domain.Enums;
using System;
using System.Collections.Generic;

namespace CidadaoAlerta.Domain.Entities
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public TipoOcorrenciaEnum TipoOcorrencia { get; set; }
        public TipoItemEnum TipoItem { get; set; }
        public DateTime Data { get; set; }

        string _descricao = string.Empty;
        public string Descricao
        {
            get
            {
                return _descricao ?? string.Empty;
            }
            set
            {
                _descricao = value;
            }
        }

        string _latitude = string.Empty;
        public string Latitude
        {
            get
            {
                return _latitude ?? string.Empty;
            }
            set
            {
                _latitude = value;
            }
        }

        string _longitude = string.Empty;
        public string Longitude
        {
            get
            {
                return _longitude ?? string.Empty;
            }
            set
            {
                _longitude = value;
            }
        }

        public List<Interacao> Interacoes { get; set; }
    }
}
