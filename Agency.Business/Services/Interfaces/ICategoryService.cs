using Agency.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(Category entity);
        Task Delete(int id);
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>>? expression = null); 
        Task UpdateAsync(Category entity);
    }
}
