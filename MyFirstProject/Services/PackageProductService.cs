using Microsoft.EntityFrameworkCore;
using MyFirstProject.Interfaces;
using MyFirstProject.Mapping;
using MyFirstProject.Models;
using MyFirstProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Services
{
    public class PackageProductService : IPackageProductService
    {
        private readonly MyFirstProjectContext _context;
        private readonly IMapper<Entities.PackageProduct, PackageProductModel> _packageProductMapper;

        public PackageProductService(MyFirstProjectContext context)
        {
            _packageProductMapper = new PackageProductMapper();
            _context = context;
        }

        public CreatePackageProductResponse CreatePackageProduct(PackageProductModel packageProduct)
        {
            var packageProductAlreadyExists = _context.PackageProducts.Any(p => p.Id == packageProduct.Id);

            if (packageProductAlreadyExists)
            {
                throw new DbUpdateException($"PackageProduct with id '{packageProduct.Id}' already exist.");
            }

            var record = _context.PackageProducts.Add(_packageProductMapper.MapFromModelToEntity(packageProduct));

            _context.SaveChanges();

            return new CreatePackageProductResponse { CreatedPackageProduct = _packageProductMapper.MapFromEntityToModel(record.Entity) };

        }

        public GetPackageProductResponse GetPackageProduct(GetPackageProductRequest getPackageProductRequest)
        {
            var packageProduct = _context.PackageProducts.Find(getPackageProductRequest.Id);

            return new GetPackageProductResponse { PackageProduct = _packageProductMapper.MapFromEntityToModel(packageProduct) };
        }







        public UpdatePackageProductResponse UpdatePackageProduct(UpdatePackageProductRequest updatePackageProductRequest)
        {
            var packageProductExist = _context.PackageProducts.Any(x => x.Id == updatePackageProductRequest.PackageProductToUpdate.Id);

            if (!packageProductExist)
            {
                throw new DbUpdateException($"PackageProduct with such ID doesn't exist");
            }

            var existingEntity = _context.PackageProducts.Find(updatePackageProductRequest.PackageProductToUpdate.Id);

            existingEntity.Id = updatePackageProductRequest.PackageProductToUpdate.Id;
            existingEntity.PackageId = updatePackageProductRequest.PackageProductToUpdate.PackageId;
            existingEntity.Package = updatePackageProductRequest.PackageProductToUpdate.Package;
            existingEntity.ProductId = updatePackageProductRequest.PackageProductToUpdate.ProductId;
            existingEntity.Product = updatePackageProductRequest.PackageProductToUpdate.Product;

        _context.SaveChanges();

            return new UpdatePackageProductResponse { UpdatedPackageProduct = updatePackageProductRequest.PackageProductToUpdate };

        }

        [HttpPost]

        public DeletePackageProductResponse DeletePackageProduct(DeletePackageProductRequest deletePackageProductRequest)
        {
            var packageProductToDelete = _context.PackageProducts.Find(deletePackageProductRequest.Id);
            if (packageProductToDelete == null)
            {
                throw new DbUpdateException($"PackageProduct with id '{deletePackageProductRequest.Id}' doesn't exist.");
            }

            _context.PackageProducts.Remove(packageProductToDelete);

            //   _context.Categories.RemoveRange(_context.Categories);
            _context.SaveChanges();

            return new DeletePackageProductResponse();
        }











    }


}

