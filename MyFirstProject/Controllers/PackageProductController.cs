using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Models;
using MyFirstProject.Interfaces;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackageProductController : Controller
    {
        private readonly IPackageProductService _packageProductService;

        public PackageProductController(IPackageProductService PackageProductService)
        {
            _packageProductService = PackageProductService;
        }

        [HttpPost("createPackageProduct")]
        public CreatePackageProductResponse CreatePackageProduct(PackageProductModel request) => _packageProductService.CreatePackageProduct(request);

        [HttpPost("getPackageProduct")]
        public GetPackageProductResponse GetPackageProduct(GetPackageProductRequest request) => _packageProductService.GetPackageProduct(request);

        [HttpPost("updatePackageProduct")]
        public UpdatePackageProductResponse UpdatePackageProduct(UpdatePackageProductRequest request) => _packageProductService.UpdatePackageProduct(request);


        [HttpPost("deletePackageProduct")]
        public DeletePackageProductResponse Delete(DeletePackageProductRequest request) => _packageProductService.DeletePackageProduct(request);
    }


}
