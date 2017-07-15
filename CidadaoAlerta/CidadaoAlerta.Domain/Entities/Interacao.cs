using System;

namespace CidadaoAlerta.Domain.Entities
{
    public class Interacao
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
