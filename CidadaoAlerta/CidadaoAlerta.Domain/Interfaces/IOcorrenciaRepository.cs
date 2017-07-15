using CidadaoAlerta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CidadaoAlerta.Domain.Interfaces
{
    public interface IOcorrenciaRepository
    {
        void Add(Ocorrencia ocorrencia);
        List<Ocorrencia> Get();
        Ocorrencia Get(int id);
    }
}
