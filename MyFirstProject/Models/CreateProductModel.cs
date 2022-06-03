using MyFirstProject.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyFirstProject.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
    }
}
