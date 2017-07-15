using System.ComponentModel;

namespace CidadaoAlerta.Domain.Enums
{
    public enum TipoOcorrenciaEnum
    {
        [Description("")]
        None = 0,
        [Description("Assalto")]
        Assalto = 1,
        [Description("Indivíduo Suspeito")]
        IndividuoSuspeito = 2,
        [Description("Briga")]
        Briga = 3
    }
}
