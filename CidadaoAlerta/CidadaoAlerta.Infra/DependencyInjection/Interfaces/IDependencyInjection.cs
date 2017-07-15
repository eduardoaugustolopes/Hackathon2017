using System;

namespace CidadaoAlerta.Infra.DependencyInjection.Interfaces
{
    public interface IDependencyInjection
    {
        T Resolve<T>();
        T Resolve<T>(Type type);
    }
}
