using MyFirstProject.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyFirstProject.Models
{
    public class CreatePackageRequest
    {
        

        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<PackageProduct> PackageProducts { get; set; }
        public string Description { get; set; }
    }
}
