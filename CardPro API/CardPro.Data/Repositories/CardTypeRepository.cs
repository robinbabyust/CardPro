using CardPro.Data.Entities;
using CardPro.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardPro.Data.Repositories
{
    public class CardTypeRepository : ICardTypeRepository
    {
        private readonly CardProDbContext _dbContext;

        public CardTypeRepository(CardProDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all card type details
        /// </summary>
        /// <returns>List of card types</returns>
        public async Task<IEnumerable<CardType>> GetCardTypes()
        {
            return await _dbContext.CardTypes.ToListAsync();
        }

        /// <summary>
        /// Get all matching card type details for the give criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns>List of card types</returns>
        public async Task<List<CardType>> GetCardTypes(Criteria criteria)
        {
            return await _dbContext.CardTypes.Where(x => x.Id == criteria.CardTypeId).ToListAsync();
        }
    }
}