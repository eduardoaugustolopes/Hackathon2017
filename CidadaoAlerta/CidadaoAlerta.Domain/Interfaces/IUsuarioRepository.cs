using CidadaoAlerta.Domain.Entities;

namespace CidadaoAlerta.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Get(string login, string senha);
    }
}
