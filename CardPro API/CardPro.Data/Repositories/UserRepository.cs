using CardPro.Data.Entities;
using CardPro.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CardPro.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CardProDbContext _dbContext;

        public UserRepository(CardProDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Save all user detailsto database
        /// </summary>
        /// <param name="user">User Enquiry details</param>
        /// <returns>Save status</returns>
        public async Task<bool> SaveUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Added;
            int affectedRows = await _dbContext.SaveChangesAsync();

            return affectedRows > 0;
        }
    }
}