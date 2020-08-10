using CardPro.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardPro.Data.Interfaces
{
    public interface ICardTypeRepository
    {
        /// <summary>
        /// Get all card type details
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CardType>> GetCardTypes();

        /// <summary>
        /// Get all matching card type details for the give criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns>List of card types</returns>
        Task<List<CardType>> GetCardTypes(Criteria criteria);
    }
}