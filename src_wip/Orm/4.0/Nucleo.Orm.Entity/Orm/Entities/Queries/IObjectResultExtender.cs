using System;
using System.Data.Objects;


namespace Nucleo.Orm.Entities.Queries
{
    public interface IObjectResultExtender<TEntity>
        where TEntity : class
    {
        ObjectResult<TEntity> Query<TUnitOfWork>(Func<TUnitOfWork, ObjectResult<TEntity>> source)
            where TUnitOfWork : IUnitOfWork;
    }
}
