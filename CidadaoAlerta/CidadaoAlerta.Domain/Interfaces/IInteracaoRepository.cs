using CidadaoAlerta.Domain.Entities;
using System.Collections.Generic;

namespace CidadaoAlerta.Domain.Interfaces
{
    public interface IInteracaoRepository
    {
        void Add(Interacao interacao);
        List<Interacao> GetPorOcorrencia(int ocorrenciaId);
    }
}
