using Microsoft.EntityFrameworkCore;
using MyFirstProject.Interfaces;
using MyFirstProject.Mapping;
using MyFirstProject.Models;
using MyFirstProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Services
{
    public class ProductService : IProductService
    {
        private readonly MyFirstProjectContext _context;
        private readonly IMapper<Entities.Product, ProductModel> _productMapper;

        public ProductService(MyFirstProjectContext context)
        {
            _productMapper = new ProductMapper();
            _context = context;
        }
        public CreateProductResponse CreateProduct(ProductModel product)
        {
            var productAlreadyExists = _context.Products.Any(p => p.Id == product.Id);

            if (productAlreadyExists)
            {
                throw new DbUpdateException($"Product with id '{product.Id}' already exist.");
            }

            var record = _context.Products.Add(_productMapper.MapFromModelToEntity(product));

            _context.SaveChanges();

            return new CreateProductResponse { CreatedProduct = _productMapper.MapFromEntityToModel(record.Entity) };

        }

        public GetProductResponse GetProduct(GetProductRequest getProductRequest)
        {
            var product = _context.Products.Find(getProductRequest.Id);

            return new GetProductResponse { Product = _productMapper.MapFromEntityToModel(product) };
 
          }

        [HttpPost]

        public UpdateProductResponse UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            var productExist = _context.Products.Any(x => x.Id == updateProductRequest.ProductToUpdate.Id);

            if (!productExist)
            {
                throw new DbUpdateException($"Product with such ID doesn't exist");
            }

            var existingEntity = _context.Products.Find(updateProductRequest.ProductToUpdate.Id);

            existingEntity.Name = updateProductRequest.ProductToUpdate.Name;
            existingEntity.Description = updateProductRequest.ProductToUpdate.Description;
            existingEntity.Price = updateProductRequest.ProductToUpdate.Price;
            existingEntity.Id = updateProductRequest.ProductToUpdate.Id;
            existingEntity.Category = updateProductRequest.ProductToUpdate.Category;

            _context.SaveChanges();

            return new UpdateProductResponse { UpdatedProduct = updateProductRequest.ProductToUpdate };

        }

        [HttpPost]

        public DeleteProductResponse DeleteProduct(DeleteProductRequest deleteProductRequest)
        {
            var ProductToDelete = _context.Products.Find(deleteProductRequest.Id);
            if (ProductToDelete == null)
            {
                throw new DbUpdateException($"Product with id '{deleteProductRequest.Id}' doesn't exist.");
            }

            _context.Products.Remove(ProductToDelete);

            //   _context.Categories.RemoveRange(_context.Categories);
            _context.SaveChanges();

            return new DeleteProductResponse();
        }

    }


}

