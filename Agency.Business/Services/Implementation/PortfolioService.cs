using Agency.Business.Services.Interfaces;
using Agency.Core.Models;
using Agency.Core.Repository.Interfaces;
using Agency.Data.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Implementation
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }
        public Task CreateAsync(Portfolio entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Portfolio>> GetAllAsync(Expression<Func<Portfolio, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<Portfolio> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Portfolio entity)
        {
            throw new NotImplementedException();
        }
    }
}
