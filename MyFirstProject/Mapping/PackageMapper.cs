using DurableTask.Core.Common;
using MyFirstProject.Interfaces;
using MyFirstProject.Models;

namespace MyFirstProject.Mapping
{


    public class PackageMapper : IMapper<Entities.Package, PackageModel>
    {
        public PackageModel MapFromEntityToModel(Entities.Package source) => new PackageModel
        {

            Name = source.Name,
            Description = source.Description,
            PackageProducts = source.PackageProducts,
            Id = source.Id,

            Price = source.Price,




            

    };

        public Entities.Package MapFromModelToEntity(PackageModel source)
        {
            var entity = new Entities.Package();

            MapFromModelToEntity(source, entity);

            return entity;
        }

        public void MapFromModelToEntity(PackageModel source, Entities.Package target)
        {
            target.Name = source.Name;
            target.Description = source.Description;
            target.Price = source.Price;
            target.Id = source.Id;
            target.PackageProducts = source.PackageProducts;
        }


    }


}

