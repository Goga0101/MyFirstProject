using MyFirstProject.Models;
using MyFirstProject.Services;

namespace MyFirstProject.Interfaces
{
    public interface IPackageService
    {
        GetPackageResponse GetPackage(GetPackageRequest request);
        CreatePackageResponse CreatePackage(PackageModel request);


        UpdatePackageResponse UpdatePackage(UpdatePackageRequest request);


        DeletePackageResponse DeletePackage(DeletePackageRequest request);
    }


}
