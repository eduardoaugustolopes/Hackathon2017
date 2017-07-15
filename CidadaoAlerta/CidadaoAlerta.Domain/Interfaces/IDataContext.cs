using System;

namespace CidadaoAlerta.Domain.Interfaces
{
    public interface IDataContext : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void Finally();
    }
}
