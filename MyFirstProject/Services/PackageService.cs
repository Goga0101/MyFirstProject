using Microsoft.EntityFrameworkCore;
using MyFirstProject.Interfaces;
using MyFirstProject.Mapping;
using MyFirstProject.Models;
using MyFirstProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Services
{
    public class PackageService : IPackageService
    {
        private readonly MyFirstProjectContext _context;
        private readonly IMapper<Entities.Package, PackageModel> _packageMapper;

        public PackageService(MyFirstProjectContext context)
        {
            _packageMapper = new PackageMapper();
            _context = context;
        }

        public CreatePackageResponse CreatePackage(PackageModel package)
        {
            var packageAlreadyExists = _context.Categories.Any(p => p.Id == package.Id);

            if (packageAlreadyExists)
            {
                throw new DbUpdateException($"Package with id '{package.Id}' already exist.");
            }

            var record = _context.Packages.Add(_packageMapper.MapFromModelToEntity(package));

            _context.SaveChanges();

            return new CreatePackageResponse { CreatedPackage = _packageMapper.MapFromEntityToModel(record.Entity) };

        }

        public GetPackageResponse GetPackage(GetPackageRequest getPackageRequest)
        {
            var package = _context.Packages.Find(getPackageRequest.Id);

            return new GetPackageResponse { Package = _packageMapper.MapFromEntityToModel(package) };
        }


        public UpdatePackageResponse UpdatePackage(UpdatePackageRequest updatePackageRequest)
        {
            var packageExist = _context.Packages.Any(x => x.Id == updatePackageRequest.PackageToUpdate.Id);

            if (!packageExist)
            {
                throw new DbUpdateException($"Package with such ID doesn't exist");
            }

            var existingEntity = _context.Packages.Find(updatePackageRequest.PackageToUpdate.Id);

            existingEntity.Name = updatePackageRequest.PackageToUpdate.Name;
            existingEntity.Description = updatePackageRequest.PackageToUpdate.Description;
            existingEntity.Price = updatePackageRequest.PackageToUpdate.Price;
            existingEntity.Id = updatePackageRequest.PackageToUpdate.Id;
            existingEntity.PackageProducts = updatePackageRequest.PackageToUpdate.PackageProducts;




            

            _context.SaveChanges();

            return new UpdatePackageResponse { UpdatedPackage = updatePackageRequest.PackageToUpdate };

        }

        [HttpPost]

        public DeletePackageResponse DeletePackage(DeletePackageRequest deletePackageRequest)
        {
            var packageToDelete = _context.Packages.Find(deletePackageRequest.Id);
            if (packageToDelete == null)
            {
                throw new DbUpdateException($"Package with id '{deletePackageRequest.Id}' doesn't exist.");
            }

            _context.Packages.Remove(packageToDelete);

            //   _context.Categories.RemoveRange(_context.Categories);
            _context.SaveChanges();

            return new DeletePackageResponse();
        }




    }


}
