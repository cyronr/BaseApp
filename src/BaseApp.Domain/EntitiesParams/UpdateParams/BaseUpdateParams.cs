using BaseApp.Domain.Entities.BaseEntities;
using Mapster;

namespace BaseApp.Domain.EntitiesParams.UpdateParams;

/// <summary>
/// Base class for UpdateParams used to update entity properties
/// </summary>
/// <typeparam name="TParams"></typeparam>
/// <typeparam name="TEntity"></typeparam>
public abstract record BaseUpdateParams<TParams, TEntity> where TParams : class where TEntity : Entity
{
    /// <summary>
    /// Mapster TypeAdapterConfig needed for mapping Params to Entity
    /// </summary>
    public static TypeAdapterConfig MappingConfig
    {
        get
        {
            TypeAdapterConfig config = new TypeAdapterConfig();
            config.NewConfig<TParams, TEntity>().NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

            return config;
        }
    }
}
