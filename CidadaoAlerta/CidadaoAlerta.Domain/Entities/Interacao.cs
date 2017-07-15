using System;

namespace CidadaoAlerta.Domain.Entities
{
    public class Interacao
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
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
    }
}
