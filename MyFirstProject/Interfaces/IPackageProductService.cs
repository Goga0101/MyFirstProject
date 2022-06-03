using MyFirstProject.Models;
using MyFirstProject.Services;

namespace MyFirstProject.Interfaces
{
    public interface IPackageProductService
    {
        GetPackageProductResponse GetPackageProduct(GetPackageProductRequest request);
        CreatePackageProductResponse CreatePackageProduct(PackageProductModel request);

        UpdatePackageProductResponse UpdatePackageProduct(UpdatePackageProductRequest request);


        DeletePackageProductResponse DeletePackageProduct(DeletePackageProductRequest request);
    }


}
