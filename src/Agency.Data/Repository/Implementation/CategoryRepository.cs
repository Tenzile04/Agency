using Agency.Core.Models;
using Agency.Core.Repository.Interfaces;
using Agency.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Data.Repository.Implementation
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context) 
        {
            
        }
    }
}
