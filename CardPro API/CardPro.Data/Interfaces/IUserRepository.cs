using CardPro.Data.Entities;
using System.Threading.Tasks;

namespace CardPro.Data.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Save all user detailsto database
        /// </summary>
        /// <param name="user">User Enquiry details</param>
        /// <returns>Save status</returns>
        Task<bool> SaveUser(User user);
    }
}