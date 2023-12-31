﻿using BaseApp.Application.Persistence;
using BaseApp.Application.Persistence.Repositories;
using BaseApp.Domain.Entities.BaseEntities;

namespace BaseApp.Infrastructure.Persistence;

internal class RepositoryFactory(IServiceProvider _serviceProvider) : IRepositoryFactory
{
    #region DI
    private readonly IServiceProvider _serviceProvider = _serviceProvider;
    #endregion

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity => 
        (IRepository<TEntity>)_serviceProvider.GetService(typeof(IRepository<TEntity>)) ?? throw new Exception($"Could not get repository for {typeof(TEntity)}");
}
