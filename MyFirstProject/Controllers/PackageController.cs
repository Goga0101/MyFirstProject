using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Models;
using MyFirstProject.Interfaces;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackageController : Controller
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpPost("createPackage")]
        public CreatePackageResponse CreatePackage(PackageModel request) => _packageService.CreatePackage(request);

        [HttpPost("getPackage")]
        public GetPackageResponse GetPackage(GetPackageRequest request) => _packageService.GetPackage(request);


        [HttpPost("updatePackage")]
        public UpdatePackageResponse UpdatePackage(UpdatePackageRequest request) => _packageService.UpdatePackage(request);


        [HttpPost("deletePackage")]
        public DeletePackageResponse Delete(DeletePackageRequest request) => _packageService.DeletePackage(request);


    }


}
