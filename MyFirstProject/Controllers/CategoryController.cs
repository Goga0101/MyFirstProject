using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Models;
using MyFirstProject.Interfaces;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("createCategory")]
        public CreateCategoryResponse CreateCategory(CategoryModel request) => _categoryService.CreateCategory(request);

        [HttpPost("getCategory")]
        public GetCategoryResponse GetCategory(GetCategoryRequest request) => _categoryService.GetCategory(request);


        [HttpPost("updateCategory")]
        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request) => _categoryService.UpdateCategory(request);


        [HttpPost("deleteCategory")]
        public DeleteCategoryResponse Delete(DeleteCategoryRequest request) => _categoryService.DeleteCategory(request);
    }


}
