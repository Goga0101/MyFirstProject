using DurableTask.Core.Common;
using MyFirstProject.Interfaces;
using MyFirstProject.Models;

namespace MyFirstProject.Mapping
{


    public class PackageProductMapper : IMapper<Entities.PackageProduct, PackageProductModel>
    {
        public PackageProductModel MapFromEntityToModel(Entities.PackageProduct source) => new PackageProductModel
        {

            PackageId = source.PackageId,
            Package = source.Package,
            Product = source.Product,
            Id = source.Id,
            ProductId = source.ProductId,





    };

        public Entities.PackageProduct MapFromModelToEntity(PackageProductModel source)
        {
            var entity = new Entities.PackageProduct();

            MapFromModelToEntity(source, entity);

            return entity;
        }

        public void MapFromModelToEntity(PackageProductModel source, Entities.PackageProduct target)
        {
            target.PackageId = source.PackageId;
            target.Package = source.Package;
            target.Product = source.Product;
            target.Id = source.Id;
            target.ProductId = source.ProductId;
        }


    }


}

