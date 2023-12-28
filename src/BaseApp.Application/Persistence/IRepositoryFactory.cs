using BaseApp.Application.Persistence.Repositories;
using BaseApp.Domain.Entities.BaseEntities;

namespace BaseApp.Application.Persistence;

public interface IRepositoryFactory
{
    /// <summary>
    /// Returns implementation of IRepository for specified entity
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;
}
