using MyFirstProject.Models;
using MyFirstProject.Services;

namespace MyFirstProject.Interfaces
{
    public interface IProductService
    {
        GetProductResponse GetProduct(GetProductRequest request);
        CreateProductResponse CreateProduct(ProductModel request);
        UpdateProductResponse UpdateProduct(UpdateProductRequest request);


        DeleteProductResponse DeleteProduct(DeleteProductRequest request);
    }


}
