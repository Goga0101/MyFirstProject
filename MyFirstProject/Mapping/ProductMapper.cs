using DurableTask.Core.Common;
using MyFirstProject.Interfaces;
using MyFirstProject.Models;

namespace MyFirstProject.Mapping
{


    public class ProductMapper : IMapper<Entities.Product, ProductModel>
    {
        public ProductModel MapFromEntityToModel(Entities.Product source) => new ProductModel
        {

            Name = source.Name,
            Description = source.Description,
            Price = source.Price,
            Id = source.Id,
            Category = source.Category,



        
    };

        public Entities.Product MapFromModelToEntity(ProductModel source)
        {
            var entity = new Entities.Product();

            MapFromModelToEntity(source, entity);

            return entity;
        }

        public void MapFromModelToEntity(ProductModel source, Entities.Product target)
        {
            target.Name = source.Name;
            target.Description = source.Description;
            target.Price = source.Price;
            target.Id = source.Id;
            target.Category = source.Category;
        }


    }


}

