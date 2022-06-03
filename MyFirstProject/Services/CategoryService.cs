using Microsoft.EntityFrameworkCore;
using MyFirstProject.Interfaces;
using MyFirstProject.Mapping;
using MyFirstProject.Models;
using MyFirstProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MyFirstProjectContext _context;
        private readonly IMapper<Entities.Category, CategoryModel> _categoryMapper;

        public CategoryService(MyFirstProjectContext context)
        {
            _categoryMapper = new CategoryMapper();
            _context = context;
        }

        [HttpPost]

        public CreateCategoryResponse CreateCategory(CategoryModel category)
        {
            var categoryAlreadyExists = _context.Categories.Any(p => p.Id == category.Id);

            if (categoryAlreadyExists)
            {
                throw new DbUpdateException($"Category with id '{category.Id}' already exist.");
            }

            var record = _context.Categories.Add(_categoryMapper.MapFromModelToEntity(category));

            _context.SaveChanges();

            return new CreateCategoryResponse { CreatedCategory = _categoryMapper.MapFromEntityToModel(record.Entity) };

        }

        [HttpGet]

        public GetCategoryResponse GetCategory(GetCategoryRequest getCategoryRequest)
        {
            var category = _context.Categories.Find(getCategoryRequest.Id);

            return new GetCategoryResponse { Category = _categoryMapper.MapFromEntityToModel(category) };
        }

        [HttpPost]

        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            var categoryExist = _context.Categories.Any(x => x.Id == updateCategoryRequest.CategoryToUpdate.Id);

            if(!categoryExist)
            {
                throw new DbUpdateException($"Category with such ID doesn't exist");
            }

            var existingEntity = _context.Categories.Find(updateCategoryRequest.CategoryToUpdate.Id);

            existingEntity.Name = updateCategoryRequest.CategoryToUpdate.Name;
            existingEntity.Description = updateCategoryRequest.CategoryToUpdate.Description;
            existingEntity.Code = updateCategoryRequest.CategoryToUpdate.Code;

            _context.SaveChanges();

            return new UpdateCategoryResponse { UpdatedCategory = updateCategoryRequest.CategoryToUpdate };

        }

        [HttpPost]

        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest deleteCategoryRequest)
        {
            var categoryToDelete = _context.Categories.Find(deleteCategoryRequest.Id);
            if (categoryToDelete == null)
            {
                throw new DbUpdateException($"Category with id '{deleteCategoryRequest.Id}' doesn't exist.");
            }

            _context.Categories.Remove(categoryToDelete);

         //   _context.Categories.RemoveRange(_context.Categories);
            _context.SaveChanges();

            return new DeleteCategoryResponse();
        }


    }


}

