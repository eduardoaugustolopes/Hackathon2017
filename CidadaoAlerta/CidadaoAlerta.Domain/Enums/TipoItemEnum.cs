using System.ComponentModel;

namespace CidadaoAlerta.Domain.Enums
{
    public enum TipoItemEnum
    {
        [Description("")]
        None = 0,
        [Description("Carro")]
        Carro = 1,
        [Description("Casa")]
        Casa = 2,
        [Description("Pessoa")]
        Pessoa = 3
    }
}
