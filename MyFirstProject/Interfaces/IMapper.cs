using MyFirstProject.Entities;
using MyFirstProject.Models;

namespace MyFirstProject.Interfaces
{
    public interface IMapper<TEntity, TModel>
    {
        TModel MapFromEntityToModel(TEntity source);

        TEntity MapFromModelToEntity(TModel source);

        void MapFromModelToEntity(TModel source, TEntity target);
    }
}
