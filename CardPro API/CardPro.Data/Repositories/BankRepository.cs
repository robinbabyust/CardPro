using CardPro.Data.Entities;
using CardPro.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardPro.Data.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly CardProDbContext _dbContext;

        public BankRepository(CardProDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all bank details
        /// </summary>
        /// <returns>List of bank details</returns>
        public async Task<IEnumerable<Bank>> GetBanks()
        {
            return await _dbContext.Banks
                .ToListAsync();
        }
    }
}