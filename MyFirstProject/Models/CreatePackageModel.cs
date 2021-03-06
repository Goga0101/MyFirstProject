using MyFirstProject.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyFirstProject.Models
{
    public class PackageModel
    {
        public PackageModel()
        {
            PackageProducts = new List<PackageProduct>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<PackageProduct> PackageProducts { get; set; }
        public string Description { get; set; }
    }
}
