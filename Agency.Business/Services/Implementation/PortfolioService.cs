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
     

        public async Task CreateAsync(Portfolio entity)
        {
            if (_portfolioRepository.Table.Any(x => x.Name == entity.Name))
                throw new NullReferenceException();

            await _portfolioRepository.CreateAsync(entity);
            await _portfolioRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {

            Portfolio portfolio = await _portfolioRepository.GetByIdAsync(x => x.IsDeleted == false && x.Id == id);

            if (portfolio is null) throw new NullReferenceException();

            _portfolioRepository.Delete(portfolio);
            await _portfolioRepository.CommitAsync();
        }

        public Task<List<Portfolio>> GetAllAsync(Expression<Func<Portfolio, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Portfolio>> GetAllAsync()
        {
            return await _portfolioRepository.GetAllAsync(p => p.IsDeleted == false);
        }

        public async Task<Portfolio> GetByIdAsync(int id)
        {
            return await _portfolioRepository.GetByIdAsync(p => p.IsDeleted == false && p.Id == id);
        }

        public async Task UpdateAsync(Portfolio entity)
        {
            Portfolio existPortfolio = await _portfolioRepository.GetByIdAsync(x => x.Id == entity.Id && x.IsDeleted == false);

            if (_portfolioRepository.Table.Any(x => x.Name.ToLower() == entity.Name.ToLower() && existPortfolio.Id != entity.Id))
            {
                throw new NullReferenceException();
            }

            existPortfolio.Name = entity.Name;

            await _portfolioRepository.CommitAsync();
        }
    }
}
