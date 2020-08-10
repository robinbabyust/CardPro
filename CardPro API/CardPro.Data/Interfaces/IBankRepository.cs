using CardPro.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardPro.Data.Interfaces
{
    public interface IBankRepository
    {
        /// <summary>
        /// Get all bank details
        /// </summary>
        /// <returns>List of bank details</returns>
        Task<IEnumerable<Bank>> GetBanks();
    }
}