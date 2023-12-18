using Agency.Business.Services.Interfaces;
using Agency.Core.Models;
using Agency.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository; 
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task CreateAsync(Category entity)
        {
            if (_categoryRepository.Table.Any(x => x.Name == entity.Name))
            throw new NullReferenceException();
            await _categoryRepository.CreateAsync(entity);
            await _categoryRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);

            if (entity is null) throw new NullReferenceException();


            _categoryRepository.Delete(entity);
            await _categoryRepository.CommitAsync();
        }
        
        public async Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>>? expression = null)
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {

            var entity = await _categoryRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);
            if (entity is null) throw new NullReferenceException();
            return entity;
        }

        public async Task UpdateAsync(Category entity)
        {
            var existEntity = await _categoryRepository.GetByIdAsync(x => x.Id == entity.Id && x.IsDeleted == false);

            if (_categoryRepository.Table.Any(x => x.Name == entity.Name && existEntity.Id != entity.Id))
                throw new NullReferenceException();

            existEntity.Name = entity.Name;
            await _categoryRepository.CommitAsync();
        }
    }
}
