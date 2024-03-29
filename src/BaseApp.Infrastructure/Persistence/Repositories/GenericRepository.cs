﻿using BaseApp.Application.Persistence.Repositories;
using BaseApp.Domain.Entities.BaseEntities;
using Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace BaseApp.Infrastructure.Persistence.Repositories;

internal abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly AppDbContext _appDbContext;
    private readonly ILogger<GenericRepository<TEntity>> _logger;
    public GenericRepository(AppDbContext appDbContext, ILogger<GenericRepository<TEntity>> logger)
    {
        _appDbContext = appDbContext;
        _logger = logger;
    }


    public async Task<TEntity?> GetByUUIDAsync(Guid uuid, Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> query = _appDbContext.Set<TEntity>().ApplyFilter(filter);

        return await query.FirstOrDefaultAsync(e => e.UUID == uuid);
    }
    public async Task<TEntity?> GetByUUIDAsNoTrackingAsync(Guid uuid, Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> query = _appDbContext.Set<TEntity>().ApplyFilter(filter);

        return await query.AsNoTracking().FirstOrDefaultAsync(e => e.UUID == uuid);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> query = _appDbContext.Set<TEntity>().ApplyFilter(filter);

        return await query.ToListAsync();
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _appDbContext.Set<TEntity>().AddAsync(entity);
    }

}
