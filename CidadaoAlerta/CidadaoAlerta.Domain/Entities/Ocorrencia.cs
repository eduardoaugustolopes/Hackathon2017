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
        public string Descricao { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public List<Interacao> Interacoes { get; set; }
    }
}
