using CardPro.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardPro.Data.Interfaces
{
    public interface ICriteriaRepository
    {
        /// <summary>
        /// Get all Criterias
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Criteria>> GetCriterias();

        /// <summary>
        /// Get all matching criterias
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<IEnumerable<Criteria>> GetCriterias(User user);
    }
}