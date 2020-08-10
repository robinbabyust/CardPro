using CardPro.Data.Entities;
using CardPro.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardPro.Data.Repositories
{
    public class CriteriaRepository : ICriteriaRepository
    {
        private readonly CardProDbContext _dbContext;

        public CriteriaRepository(CardProDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Get all Criterias
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Criteria>> GetCriterias()
        {
            return await _dbContext.Criterias.ToListAsync();
        }

        /// <summary>
        /// Get all matching criterias
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Criteria>> GetCriterias(User user)
        {
            int age = CalculateAge(user);

            return await _dbContext.Criterias.Where(x => x.MinimumAge <= age && x.MinimumIncome <= user.AnnualIncome).ToListAsync();
        }

        private static int CalculateAge(User user)
        {
            int age = 0;
            age = DateTime.Now.Year - user.DateOfBirth.Year;

            if (DateTime.Now.DayOfYear < user.DateOfBirth.DayOfYear)
            {
                age = age - 1;
            }

            return age;
        }
    }
}